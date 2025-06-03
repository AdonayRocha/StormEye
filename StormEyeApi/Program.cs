using Microsoft.EntityFrameworkCore;
using StormEyeApi.Data;

var builder = WebApplication.CreateBuilder(args);

// Configura o HttpClient para chamadas externas 
builder.Services.AddHttpClient();

// Configura o EF Core com Oracle
builder.Services.AddDbContext<StormEyeContext>(options =>
    options.UseOracle(builder.Configuration.GetConnectionString("OracleDb")));

// Adiciona suporte a controllers
builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

// Adiciona suporte ao Swagger 
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseCors("AllowAll");

// Habilita Swagger no ambiente de desenvolvimento
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
