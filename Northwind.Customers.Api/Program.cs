using Microsoft.EntityFrameworkCore;
using Northwind.Customers.Application.Contracts;
using Northwind.Customers.Persistence.Context;
using Northwind.Customers.Service;
using Northwind.Customers.IOC.Dependency; // Aseg�rate de que esta l�nea est� presente

var builder = WebApplication.CreateBuilder(args);

// Configurar la cadena de conexi�n
var connstring = builder.Configuration.GetConnectionString("NorthwindContext");

// Registrar el contexto de la base de datos
builder.Services.AddDbContext<NorthwindCustomerContext>(options =>
    options.UseSqlServer(connstring));

// Registrar otras dependencias necesarias para clientes
builder.Services.AddCustomerDependency(); // Esta l�nea asegura que se registren las dependencias

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
