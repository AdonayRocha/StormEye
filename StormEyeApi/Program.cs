using Microsoft.EntityFrameworkCore;
using StormEyeApi.Data;

var builder = WebApplication.CreateBuilder(args);

// Configura o HttpClient para chamadas externas (ex: GDACS API)
builder.Services.AddHttpClient();

// Configura o EF Core com Oracle
builder.Services.AddDbContext<StormEyeContext>(options =>
    options.UseOracle(builder.Configuration.GetConnectionString("OracleDb")));

// Adiciona suporte a controllers
builder.Services.AddControllers();

// Adiciona CORS para permitir chamadas do StormEyeWeb
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

// Adiciona suporte ao Swagger (documentação da API)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Ativa CORS
app.UseCors("AllowAll");

// Habilita Swagger no ambiente de desenvolvimento
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Middleware de autorização (autenticação, se for o caso)
app.UseAuthorization();

// Mapeia os endpoints dos controllers
app.MapControllers();

// Inicia a aplicação
app.Run();
