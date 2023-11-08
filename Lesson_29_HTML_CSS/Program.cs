using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// [PC] hardware
// [PC] software
// [ASP.NET] middleware

// GET /index.html HTTP/1.1
// Host: 127.0.0.1:3456
// Accept-Language: ua

// localhost == 127.0.0.1

// (in client's browser) http://127.0.0.1:3456/ --> [HW] http://127.0.0.1:3456/ --> [OS] -->
//   --> [asp.net] --> [UseDefaultFiles] --> http://127.0.0.1:3456/index.html --> [PhysicalFileProvider] --> ./wwwroot/index.html --> back to the client
app.UseDefaultFiles();
app.UseStaticFiles(new StaticFileOptions {
    FileProvider = new PhysicalFileProvider(
        Path.Combine(Directory.GetCurrentDirectory(), "wwwroot")),
});

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
