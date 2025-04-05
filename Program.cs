using Anuncia_Picos.Components;
using System.Net.Http;

var builder = WebApplication.CreateBuilder(args);

// Registra o HttpClient
builder.Services.AddHttpClient();

// Adiciona os componentes do Blazor
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();
builder.WebHost.UseUrls("http://localhost:5009");

// Configura o pipeline de requisição HTTP
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts(); // Política de segurança para HSTS (HTTP Strict Transport Security)
}

app.UseHttpsRedirection();  // Redireciona para HTTPS
app.UseStaticFiles();       // Para servir arquivos estáticos como JS, CSS, imagens

// Coloque o middleware de antiforgery depois de UseRouting e antes de UseEndpoints
app.UseRouting(); 

app.UseAntiforgery(); // Adiciona o middleware antiforgery



app.Run();
