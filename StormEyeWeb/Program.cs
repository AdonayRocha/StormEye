using Microsoft.EntityFrameworkCore;
using StormEyeWeb.Config;
using StormEye.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient("StormEyeAPI", client =>
{
    client.BaseAddress = new Uri("https://localhost:5001/");
});

builder.Services.AddRazorPages();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
