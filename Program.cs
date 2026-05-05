using MarsRoverPhotoFetcher.Models;
using MarsRoverPhotoFetcher.Services.Implementations;
using MarsRoverPhotoFetcher.Services.Interfaces;
using Microsoft.AspNetCore.Diagnostics;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<NasaOptions>(builder.Configuration.GetSection("Nasa"));

// Add services to the container.
builder.Services.AddScoped<IDatesService, DatesService>();
builder.Services.AddScoped<IDateParser, DateParser>();
builder.Services.AddHttpClient<IRoverImageDownloader, RoverImageDownloader>();
builder.Services.AddScoped<IRoverJobService, RoverJobService>();
builder.Services.AddHttpClient<INasaMarsRoverClient, NasaMarsRoverClient>();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngular",
        policy =>
        {
            policy.WithOrigins("http://localhost:4200")
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

var app = builder.Build();

app.UseCors("AllowAngular");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseExceptionHandler(errorApp =>
{
    errorApp.Run(async context =>
    {
        context.Response.StatusCode = 500;
        context.Response.ContentType = "application/json";

        var error = context.Features.Get<IExceptionHandlerFeature>()?.Error;

        var result = JsonSerializer.Serialize(new
        {
            message = "An unexpected error occurred.",
            detail = error?.Message
        });

        await context.Response.WriteAsync(result);
    });
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
