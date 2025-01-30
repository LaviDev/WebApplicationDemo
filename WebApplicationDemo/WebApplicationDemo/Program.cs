using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using WebApplicationDemo.DataContext;
using WebApplicationDemo.Modelo.DTOs;
using WebApplicationDemo.Modelo.Entities;
using WebApplicationDemo.ProfileMapper;
using WebApplicationDemo.Repositories.Implements;
using WebApplicationDemo.Repositories.Interfaces;
using WebApplicationDemo.Service.Implements;
using WebApplicationDemo.Service.Interface;




var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


//Configuracion JWT
builder.Configuration.AddJsonFile("appsettings.json");
var secretKey = builder.Configuration.GetSection("settings").GetSection("secretKey").ToString();
var keyBytes = Encoding.UTF8.GetBytes(secretKey);

//Implementacion de JWT

builder.Services.AddAuthentication(config =>
{
    config.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    config.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

}).AddJwtBearer(config =>
{

    config.RequireHttpsMetadata = false;
    config.SaveToken = true;
    config.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(keyBytes),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

//Repositorios
//builder.Services.AddScoped<IUsuarioRepository<Usuario>, UsuarioRepository>();
builder.Services.AddScoped<IGenericRepository<Cita>, CitaRepository>();
builder.Services.AddScoped<IGenericRepository<Diagnostico>, DiagnosticoRepository>();
builder.Services.AddScoped<IGenericRepository<Medico>, MedicoRepository>();
builder.Services.AddScoped<IGenericRepository<Paciente>, PacienteRepository>();

//Servicios
//builder.Services.AddScoped<IGenericService<UsuarioDTO>, UsuarioService>();
//builder.Services.AddScoped<IGenericService<CitaDTO>, CitaService>();
builder.Services.AddScoped<IGenericService<MedicoDTO>, MedicoService>();
builder.Services.AddScoped<IGenericService<PacienteDTO>, PacienteService>();
//builder.Services.AddScoped<IGenericService<UsuarioDTO>, UsuarioService>();

//builder.Services.AddScoped<IMedicoRepository<Medico>, MedicoRepositories>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DemoContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionCitasDbContext")));
builder.Services.AddDbContext<UsuarioDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionCitasDbContext")));
var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new ProfileMapper());
});

IMapper mapper = mapperConfig.CreateMapper();

builder.Services.AddSingleton(mapper);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

//Referencia Jwt
app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
