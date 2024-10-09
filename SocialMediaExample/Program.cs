using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using SocialMediaExample.Data;
using SocialMediaExample.Filters;
using SocialMediaExample.Interfaces;
using SocialMediaExample.Options;
using SocialMediaExample.Repositories;
using SocialMediaExample.Services;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Configurar las opciones del token
var secureKey = SecurityUtils.GenerateSecureKey(32);
builder.Services.Configure<TokenOptions>(options =>
{
    options.SecretKey = secureKey;
    options.Issuer = "https://localhost:44372/";
    options.Audience = "https://localhost:44372/";
    options.ExpirationInMinutes = 60;
});

// Configurar el contexto de la base de datos
builder.Services.AddDbContext<SocialMediaContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Repositorios
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IPostRepository, PostRepository>();

// Servicios
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IPostService, PostService>();
builder.Services.AddScoped<IPasswordService, PasswordService>();
builder.Services.AddScoped<ITokenService, TokenService>();

// Configurar servicios adicionales
builder.Services.AddControllers(options =>
{
    options.Filters.Add<GlobalExceptionFilter>();
    options.Filters.Add<ValidationFilter>();
}).AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
    options.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
})
.ConfigureApiBehaviorOptions(options =>
{
    //options.SuppressModelStateInvalidFilter = true;
});

// Configurar AutoMapper y FluentValidation
builder.Services.AddFluentValidationAutoValidation()
        .AddFluentValidationClientsideAdapters();
builder.Services.AddValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());

// Configuración de autenticación JWT
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    var configuration = builder.Configuration;
    var issuer = builder.Configuration["TokenOptions:Issuer"];
    var audience = builder.Configuration["TokenOptions:Audience"];
    var secretKey = builder.Configuration["TokenOptions:SecretKey"];

    if (string.IsNullOrEmpty(issuer) || string.IsNullOrEmpty(audience) || string.IsNullOrEmpty(secretKey))
    {
        throw new ArgumentNullException("Issuer, Audience, or SecretKey is null or empty.");
    }

    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["TokenOptions:Issuer"],
        ValidAudience = builder.Configuration["TokenOptions:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["TokenOptions:SecretKey"]))
    };
});

builder.Services.AddHttpContextAccessor();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new() { Title = "Social Media API", Version = "v1" });
});

var app = builder.Build();

// Configuración del middleware
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "Social Media API V1");
        options.RoutePrefix = string.Empty; // Para servir la UI en la raíz de la aplicación
    });
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
