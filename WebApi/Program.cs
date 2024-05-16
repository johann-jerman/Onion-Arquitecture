using Microsoft.EntityFrameworkCore;
using Configuration;
using Application.Service;
using Application.IRepositorys;
using DataAccess;
using System.Text.Json.Serialization;
using Application.Helpers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});
builder.Services.AddCors(options =>
{
    options.AddPolicy("Cors", builder =>
    {
        builder.AllowAnyMethod(); // -> Dont do that in production
        //builder.WithMethods("GET","POST", "PUT", "DELETE");
        builder.AllowAnyOrigin();// -> Dont do that in production
        //builder.WithOrigins("http://localhost:3000"); -> configure origins -> this can be a service
        builder.AllowAnyHeader();// -> Dont do that in production
        //builder.WithHeaders("Authorization", "Content-Type"); -> configure headers
    });
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Injection dependenci of Services
builder.Services.AddScoped<CategoryService>();
builder.Services.AddScoped<ProductService>();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<OrderService>();
builder.Services.AddScoped<OrderProductService>();
builder.Services.AddScoped<AuthService>();

// Injection dependenci of Repositorys
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IOrderProductRepository, OrderProductRepository>();

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

//app.UseCors("Cors"); -> enable this for use cors configuration

app.UseAuthorization();

app.MapControllers();

app.Run();
