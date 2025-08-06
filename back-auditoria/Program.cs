using auditoriaBackend.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Agrega servicios al contenedor
builder.Services.AddControllers();
builder.Services.AddDbContext<EncuestaDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("EncuestaDbContext")));

// Configuraci�n tradicional de Swagger
builder.Services.AddEndpointsApiExplorer(); // Necesario para que Swagger detecte los endpoints
builder.Services.AddSwaggerGen(); // Registra el generador de Swagger

var app = builder.Build();

// Configura el pipeline HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();             // Genera el archivo swagger.json
    app.UseSwaggerUI();           // Habilita la interfaz gr�fica de Swagger
}

app.UseAuthorization();

app.MapControllers();

app.Run();
