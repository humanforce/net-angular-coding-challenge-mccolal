using AngularApp3.Server.Services;
using SprintSummary.server.Models;
using SprintSummary.server.Models.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IJiraUserService, JiraUserService>();
builder.Services.AddSingleton<IJiraCapacityService, JiraCapacityService>();
builder.Services.AddSingleton<IJiraDataService, JiraDataService>();
builder.Services.AddSingleton<IPublicHolidayService, PublicHolidayService>();
builder.Services.AddSingleton<ISprintDataService, SprintDataService>();



var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
