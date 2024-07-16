using Microsoft.EntityFrameworkCore;
using Northwind.Categories.Application.Contracts;
using Northwind.Categories.Persistence.Context;
using Northwind.Categories.Service;
using Northwind.Categories.IOC.Dependency; // Asegúrate de que esta línea esté presente

var builder = WebApplication.CreateBuilder(args);

// Configurar la cadena de conexión
var connstring = builder.Configuration.GetConnectionString("NorthwindContext");

// Registrar el contexto de la base de datos
builder.Services.AddDbContext<NorthwindContext>(options =>
    options.UseSqlServer(connstring));

// Registrar otras dependencias necesarias para categorías
builder.Services.AddCategoryDependency(); // Esta línea asegura que se registren las dependencias

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configurar el pipeline de solicitudes HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
