using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using StormEye.Infrastructure.Data;   
using StormEyeApi;           

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<StormEyeContext>(options =>
    options.UseOracle(builder.Configuration.GetConnectionString("OracleDb"))
);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});


builder.Services.AddControllers()
    .AddNewtonsoftJson();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//    - BaseAddress = https://www.gdacs.org/gdacsapi/api/
//    - Aceita JSON
builder.Services.AddHttpClient<IGdacsService, GdacsService>(client =>
{
    client.BaseAddress = new Uri("https://www.gdacs.org/gdacsapi/api/");
    client.DefaultRequestHeaders.Add("Accept", "application/json");
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "StormEye API v1");
    });
}

app.UseHttpsRedirection();
app.UseCors("AllowAll");
app.UseAuthorization();

app.MapControllers();

app.Run();
