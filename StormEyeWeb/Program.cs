using Microsoft.EntityFrameworkCore;
using StormEyeWeb.Config;
using StormEyeApi.Data; // <-- importante
// Adicione qualquer outro using necess�rio (como System)

var builder = WebApplication.CreateBuilder(args);

// Configura��o da API externa (se aplic�vel)
builder.Services.Configure<GdacsSettings>(builder.Configuration.GetSection("GdacsApi"));
builder.Services.AddHttpClient();

// Registra o DbContext (precisa da connection string no appsettings.json do Web tamb�m)
builder.Services.AddDbContext<StormEyeContext>(options =>
    options.UseOracle(builder.Configuration.GetConnectionString("OracleDb")));

builder.Services.AddRazorPages();

var app = builder.Build();

// Pipeline padr�o
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
