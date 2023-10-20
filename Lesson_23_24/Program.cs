// See https://aka.ms/new-console-template for more information
using System.Text.Json;

void SomeMethod()
{
    //await Task.Delay(1000); - forbidden
}

// When you need to attach an async event handler to the EventHandler delegate
async void SomeOtherMethodAsync()
{
    await Task.Delay(1000);
    await Task.Delay(1000);
    throw new Exception("Some very bad exception");
}

async Task SomeMethodAsync(CancellationToken cancellationToken)
{
    await Task.Delay(1000);
    // So, turns out I did a terribly stupid mistake here. See
    // what I've done with silent way of treating cancellation
    // request? When the tokenSource.Cancel() get's triggered
    // immediately after task being launched the method just
    // silently exits, so we don't catch any Exception, because
    // there were none 😭
    // if (cancellationToken.IsCancellationRequested) {
    //     return;
    // }
    // If I replace it with ThrowIfCancellationRequested 
    // everything gonna work as intended, go see it yourself
    cancellationToken.ThrowIfCancellationRequested();

    await Task.Delay(1000);
    cancellationToken.ThrowIfCancellationRequested();

    throw new Exception("Some very bad exception");
}

async Task<int> SomeMethodWithResultAsync()
{
    await Task.Delay(1000);
    return 10;
}



HttpClient client = new HttpClient(); // Hyper Text Transfer Protocol (Secured) – 1.1
Task<string?> resultTask = client.GetStringAsync("https://api.open-meteo.com/v1/forecast?latitude=52.52&longitude=13.41&current=temperature_2m,windspeed_10m&hourly=temperature_2m,relativehumidity_2m,windspeed_10m"); // IO bound task

string? stringResultAwaited = await resultTask; // Nullable-type – Nullable<string>

// Console.WriteLine(result.Result); // DON'T DO LIKE THAT – thread blocking operation 

CancellationTokenSource tokenSource = new CancellationTokenSource();
try
{
    string stringResult = await client.GetStringAsync("https://api.open-meteo.com/v1/forecast?latitude=52.52&longitude=13.41&current=temperature_2m,windspeed_10m&hourly=temperature_2m,relativehumidity_2m,windspeed_10m", tokenSource.Token);
    Console.WriteLine(stringResult);

    await Task.WhenAll(
        SomeMethodAsync(tokenSource.Token),
        Task.Run(() => tokenSource.Cancel()));

    // methodResult.GetAwaiter().GetResult(); // its better then methodResult.Result
}
catch (TaskCanceledException)
{
    Console.WriteLine("Server took too long to respond :(");
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}