using Microsoft.EntityFrameworkCore;
using Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
string DbConectionString = builder.Configuration.GetConnectionString("DbConnectionsString");

builder.Services.AddDbContext<Context>(option =>
{
    var ServerVersion = new MySqlServerVersion(new Version(8, 0, 33));
    option.UseMySql(DbConectionString, ServerVersion);
});

var app = builder.Build();

using(var scope = app.Services.CreateScope())
{
    //var MySqlContext = scope.ServiceProvider.GetRequiredService<Context>();
    //MySqlContext.Database.Migrate();
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
