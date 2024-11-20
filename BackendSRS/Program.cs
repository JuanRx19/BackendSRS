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
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Token JWT
var jwtSettings = builder.Configuration.GetSection("JwtSettings");
var secretKey = jwtSettings["Secret"];
var issuer = jwtSettings["Issuer"];
var audience = jwtSettings["Audience"];

Console.WriteLine($"SecretKey: {secretKey}");
Console.WriteLine($"Issuer: {issuer}");
Console.WriteLine($"Audience: {audience}");

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = issuer,
        ValidAudience = audience,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))
    };
});

builder.Services.AddDbContext<BdtransporteUniversitarioContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
    new MySqlServerVersion(new Version(8, 0, 21))));

// Configura Swagger
builder.Services.AddScoped<IAlertasRepository, AlertasRepository>();
builder.Services.AddScoped<AlertasService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IDispositivosRepository, DispositivosRepository>();
builder.Services.AddScoped<UsuariosService>();
builder.Services.AddScoped<InventarioService>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IEncriptacionService, EncriptacionService>();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend",
        policy => policy.WithOrigins("http://localhost:5173") // URL del frontend
                         .AllowAnyHeader()
                         .AllowAnyMethod()
                         .AllowCredentials()
                         );
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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.UseCors("AllowFrontend");


app.Run();
