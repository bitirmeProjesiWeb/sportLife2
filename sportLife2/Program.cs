using AutoMapper;
using Microsoft.EntityFrameworkCore;
using sportLife2.DTOs;
using sportLife2.Properties.Models;
using sportLife2.Repositories;
using sportLife2.Repositories.Interface;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddTransient<IPitchRepository, PitchRepository>();
builder.Services.AddTransient<IRezervationRepository, RezervationRepository>();
builder.Services.AddTransient<ISessionRepository, SessionRepository>();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var connectionString = builder.Configuration.GetConnectionString("PostgreSqlConnectionString");
builder.Services.AddDbContext<DataBaseContext>(options => options.UseNpgsql(connectionString));
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins("http://localhost:3000") // Ýzin vermek istediðiniz kaynak
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});
var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors();

app.UseHttpsRedirection();
app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();


app.Run();
