using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using BackendSRS.Application.Services;
using BackendSRS.Domain.Repositories;
using BackendSRS.Infrastructure.Repositories;
using BackendSRS.Models;
using BackendSRS.Infrastructure.DBContexts;
using BackendSRS.Domain.Interfaces;
using BackendSRS.Infrastructure.Services;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddDbContext<BdtransporteUniversitarioContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
    new MySqlServerVersion(new Version(8, 0, 21))));

// Configura Swagger
builder.Services.AddScoped<IAlertasRepository, AlertasRepository>();
builder.Services.AddScoped<IAlertasService, AlertasService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IDispositivosRepository, DispositivosRepository>();
builder.Services.AddScoped<UsuariosService>();
builder.Services.AddScoped<InventarioService>();
builder.Services.AddScoped<IEncriptacionService, EncriptacionService>();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend",
        policy => policy.WithOrigins("http://localhost:5173") // URL del frontend
                         .AllowAnyHeader()
                         .AllowAnyMethod());
});
builder.Services.AddControllers().AddNewtonsoftJson();

var app = builder.Build();

app.UseCors("AllowFrontend");
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.UseCors("AllowFrontend");


app.Run();
