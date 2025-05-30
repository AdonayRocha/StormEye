using Microsoft.EntityFrameworkCore;
using StormEyeApi.Data;

var builder = WebApplication.CreateBuilder(args);

// Adiciona servi�os ao container
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient();

// Adiciona Oracle EF Core
builder.Services.AddDbContext<StormEyeContext>(options =>
    options.UseOracle(builder.Configuration.GetConnectionString("OracleDb")));

var app = builder.Build();

// Configura��o de middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
