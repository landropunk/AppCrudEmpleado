using AppCrud.Data;
using Microsoft.EntityFrameworkCore;

// Crea una nueva instancia de WebApplication.
var builder = WebApplication.CreateBuilder(args);

// Agrega servicios al contenedor.
builder.Services.AddControllersWithViews();

// Agrega el contexto de la base de datos al contenedor de servicios.
builder.Services.AddDbContext<AppDBContext>(options =>
{
    // Configura el contexto para usar SQL Server con la cadena de conexi�n especificada.
    options.UseSqlServer(builder.Configuration.GetConnectionString("CadenaSQL"));
});

// Construye la aplicaci�n.
var app = builder.Build();

// Configura el pipeline de solicitudes HTTP.
if (!app.Environment.IsDevelopment())
{
    // Usa el manejador de excepciones en entornos que no sean de desarrollo.
    app.UseExceptionHandler("/Home/Error");
}
// Usa archivos est�ticos.
app.UseStaticFiles();

// Usa enrutamiento.
app.UseRouting();

// Usa autorizaci�n.
app.UseAuthorization();

// Configura la ruta por defecto.
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Empleado}/{action=Lista}/{id?}");

// Ejecuta la aplicaci�n.
app.Run();
