using Anuncia_Picos.Components;
using System.Net.Http;

var builder = WebApplication.CreateBuilder(args);

// Configurações do CORS para permitir qualquer origem
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
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
app.UseStaticFiles();
app.UseCors("AllowAll");

app.UseAntiforgery(); // 🔥 Adicionado para evitar erro 500 relacionado a antiforgery

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
