using Microsoft.EntityFrameworkCore;
using ReviewWebAPI.Data;
using ReviewWebAPI.Repositories.Implementation;
using ReviewWebAPI.Repositories.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("PokemonConnectionString")); //Injecting the connection connection string
});

builder.Services.AddScoped<IPokemonRepository, PokemonRepository>();
/*
builder.Services.AddScoped<>();
builder.Services.AddScoped<>();
builder.Services.AddScoped<>();
builder.Services.AddScoped<>();
builder.Services.AddScoped<>();
*/
var app = builder.Build();

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
