using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SistemasFuncionario.Data;
using SistemasFuncionario.Models;


var builder = WebApplication.CreateBuilder(args);

// Banco de dados
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Login e permissões (Identity)
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

// MVC (Controllers + Views)
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configuração do pipeline HTTP
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthentication();   // ordem importa: Authentication antes de Authorization
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();