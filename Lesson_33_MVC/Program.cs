using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Lesson_33_MVC.Data;
using Lesson_33_MVC.Data.Models;
using Lesson_33_MVC.DTO;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpContextAccessor();
builder.Services.AddHttpClient(string.Empty, (services, client) => {
    var contextAccessor = services.GetRequiredService<IHttpContextAccessor>();
    client.BaseAddress = new Uri($"{contextAccessor.HttpContext?.Request.Scheme}://{contextAccessor.HttpContext?.Request.Host.Value}");
    client.Timeout = TimeSpan.FromSeconds(30);
});

builder.Services.AddDbContext<AppDbContext>();

builder.Services
    .AddAutoMapper(config => {
        config.CreateMap<Contact, GetContactDto>();
        config.CreateMap<CreateContactDto, Contact>();
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
