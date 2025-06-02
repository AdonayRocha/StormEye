using Microsoft.EntityFrameworkCore;
using StormEyeWeb.Config;
using StormEyeApi.Data; // <-- importante
// Adicione qualquer outro using necessário (como System)

var builder = WebApplication.CreateBuilder(args);

// Configuração da API externa (se aplicável)
builder.Services.Configure<GdacsSettings>(builder.Configuration.GetSection("GdacsApi"));
builder.Services.AddHttpClient();

// Registra o DbContext (precisa da connection string no appsettings.json do Web também)
builder.Services.AddDbContext<StormEyeContext>(options =>
    options.UseOracle(builder.Configuration.GetConnectionString("OracleDb")));

builder.Services.AddRazorPages();

var app = builder.Build();

// Pipeline padrão
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages().WithStaticAssets();

app.Run();
