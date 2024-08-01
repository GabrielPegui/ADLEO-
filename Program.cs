using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ADLEO;

var builder = WebApplication.CreateBuilder(args);

// Configura los servicios
builder.Services.AddControllers(); // Agrega esta línea para permitir API controllers
builder.Services.AddDbContext<ApplicationDbContext>(options =>
options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"), new MySqlServerVersion(new Version(8, 0, 25))));

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllers(); // Agrega esta línea para enrutar las solicitudes a los controladores

// Mapea las rutas estáticas para los archivos HTML
app.MapGet("/", async context =>
{
    await context.Response.SendFileAsync("wwwroot/login.html");
});
app.MapGet("/estudiantes", async context =>
{
    await context.Response.SendFileAsync("wwwroot/estudiantes.html");
});
app.MapGet("/cursos", async context =>
{
    await context.Response.SendFileAsync("wwwroot/cursos.html");
});
app.MapGet("/inscripcion", async context =>
{
    await context.Response.SendFileAsync("wwwroot/inscripcion.html");
});
app.MapGet("/maestros", async context =>
{
    await context.Response.SendFileAsync("wwwroot/maestros.html");
});
app.MapGet("/secciones", async context =>
{
    await context.Response.SendFileAsync("wwwroot/secciones.html");
});
app.MapGet("/home", async context =>
{
    await context.Response.SendFileAsync("wwwroot/home.html");
});


app.Run();