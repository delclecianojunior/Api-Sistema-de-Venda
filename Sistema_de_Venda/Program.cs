using Data.Context;
using Microsoft.EntityFrameworkCore;
using Sistema_de_Venda.Configurations;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Adicione serviços ao aplicativo.
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

var services = builder.Services;

var chaveSecreta = "MEUTOKENVERIFICACAO2024**"; // Substitua pela sua chave secreta
var key = Encoding.ASCII.GetBytes(chaveSecreta);

services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});

//Configuração
services.AddScoped<Business.Services.UsuarioService>();
services.AddScoped<Data.Repository.UsuarioRepository>();
services.AddScoped<Business.Services.ProdutoService>();
services.AddScoped<Data.Repository.ProdutoRepository>();
services.AddScoped<Business.Services.VendedorService>();
services.AddScoped<Data.Repository.VendedorRepository>();
services.AddScoped<Business.Services.VendaService>();
services.AddScoped<Data.Repository.VendaRepository>();
services.AddScoped<Business.Services.ItemVendaService>();
services.AddScoped<Data.Repository.ItemVendaRepository>();
services.AddScoped<Data.Repository.ComissaoRepository>();
services.AddScoped<Business.Services.ComissaoService>();
services.AddScoped<Sistema_de_Venda.Configurations.TokenService>();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins("http://127.0.0.1:5500")
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddDbContext<Contexto>(op => op.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.ResolveDependencies();
builder.Services.AddAutoMapper(typeof(AutomapperConfig));

builder.Services.AddSwaggerGen();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(); // Habilitar CORS

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.MapControllers();

app.UseAuthentication();
app.UseAuthorization();

//app.MapRazorPages();

app.Run();
