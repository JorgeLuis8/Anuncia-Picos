using Anuncia_Picos.Components;
using System.Net.Http;

var builder = WebApplication.CreateBuilder(args);

// Configurações do CORS para permitir qualquer origem
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin() // Permitir qualquer origem
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});
// Adiciona os componentes do Blazor
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

// Configura o pipeline de requisição HTTP
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();  // Para servir arquivos estáticos como JS, CSS, imagens
app.UseCors("AllowAll");  // Aplica o CORS para permitir acessos de qualquer origem

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
