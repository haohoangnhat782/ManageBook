
using Microsoft.EntityFrameworkCore;
using InfrastructureLayer;
using ApplicationLayer.Service.Contract;
using Microsoft.OpenApi.Models;
using DomainLayer.Interfaces;
using InfrastructureLayer.Repositories;
using ApplicationLayer.Service.Services;


var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

// Cấu hình Swagger
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "ManagaBook API", Version = "v1" });
});

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection"));
});


builder.Services.AddScoped(typeof(DomainLayer.Interfaces.IGenericRepository<>), typeof(InfrastructureLayer.Repositories.GenericRepository<>));
builder.Services.AddScoped<IUserService, UserService>();  
builder.Services.AddScoped<IUserRepository, UserRepository>();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); 
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "ManagaBook API v1");
        c.RoutePrefix = string.Empty; 
    });
}

app.UseAuthorization();

app.MapControllers();

app.Run();
