using Microsoft.AspNetCore.Authentication.Cookies;
using ALLmoco.Data;
using Microsoft.EntityFrameworkCore;


// esse bloco de codigo se torna importante pois ele é um bloco feito para usar o banco, não pode ser apagado pois atualiza de acordo com o banco padrão que o sistema usa
var builder = WebApplication.CreateBuilder(args);
    builder.Services.AddDbContext<AppDbContext>(options =>
        options.UseNpgsql(
            builder.Configuration.GetConnectionString("DefaultConnection"))); // "Use o BANCO e crie o banco allmoco.db" 


// bloco responsável por dizer ao ASP.NET "Vamos usar autenticacao por cookies"
builder.Services
    .AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Login"; // essa função loginPath diz ao asp.net, "se nao tiver autenticado, manda pro login"
    });


// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();

    db.Database.Migrate();
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
