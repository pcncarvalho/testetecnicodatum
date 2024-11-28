using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;
using System.Text;
using TestePraticoDATUM.Api.PostNotification;
using TestePraticoDATUM.Api.PushNotification;
using TestePraticoDATUM.Core.Repositories;
using TestePraticoDATUM.Core.Services;
using TestePraticoDATUM.Infrastructure;
using TestePraticoDATUM.Infrastructure.Auth;
using TestePraticoDATUM.Infrastructure.Persistence.Repositories;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Injecao de Dependencia
builder.Services.AddScoped<IPostRepository, PostRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IAuthService, AuthService>();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

builder.Services.AddHostedService<PostNotificationWorker>();

var connectionString = builder.Configuration.GetConnectionString("TestePraticoDATUMCs");
builder.Services.AddDbContext<TestePraticoDATUMDbContext>(options =>
    options.UseSqlServer(connectionString));

var jwtIssuer = builder.Configuration["Jwt:Issuer"];
var jwtAudience = builder.Configuration["Jwt:Audience"];
var jwtKey = builder.Configuration["Jwt:Key"];

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = jwtIssuer,
                        ValidAudience = jwtAudience,
                        IssuerSigningKey = new SymmetricSecurityKey
                       (Encoding.UTF8.GetBytes(jwtKey))
                    };
                });


var app = builder.Build();

app.MapHub<PostNotificationHubSignalR>("/hubs/post");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseAuthentication();

app.MapControllers();

app.Run();
