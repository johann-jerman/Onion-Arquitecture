using Microsoft.EntityFrameworkCore;
using Configuration;
using Application.Service;
using Application.IRepositorys;
using DataAccess;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Injection dependenci of Services
builder.Services.AddScoped<CategoryService>();
builder.Services.AddScoped<ProductService>();

// Injection dependenci of Repositorys
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();

string DbConectionString = builder.Configuration.GetConnectionString("DbConnectionsString") ?? "";

builder.Services.AddDbContext<Context>(option =>
{
    var ServerVersion = new MySqlServerVersion(new Version(8, 0, 33));
    option.UseMySql(DbConectionString, ServerVersion);
}, ServiceLifetime.Scoped);

var app = builder.Build();

using(var scope = app.Services.CreateScope())
{
    var MySqlContext = scope.ServiceProvider.GetRequiredService<Context>();
    MySqlContext.Database.Migrate();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
