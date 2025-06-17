using Microsoft.EntityFrameworkCore;
using TurismoApp.Data; // Certifique-se de que AppDbContext est� neste namespace

var builder = WebApplication.CreateBuilder(args);

// Adiciona suporte a Razor Pages
builder.Services.AddRazorPages();

// Configura o AppDbContext com SQL Server
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Middleware para tratamento de exce��es em produ��o
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}

// Habilita arquivos est�ticos (wwwroot)
app.UseStaticFiles();

// Configura o roteamento
app.UseRouting();

// Mapeia as Razor Pages
app.MapRazorPages();

// Executa a aplica��o
app.Run();
