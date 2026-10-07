using Scalar.AspNetCore;
using Serilog;

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    .WriteTo.Console()
    .WriteTo.File("logs/log-.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog();

 builder.Services.AddCors(options =>

{

    options.AddPolicy("AllowLocalhost", policy =>

    {

        policy.WithOrigins("http://127.0.0.1:5500", "http://localhost:5500/")

        .AllowAnyHeader()

        .AllowAnyMethod();

    });

});
// Add services to the container.
builder.Services.AddOpenApi();
builder.Services.AddControllers();
builder.Services.AddScoped<MyWebApp.Models.AppDbContext>();
builder.Services.AddScoped<MyWebApp.Services.SubjectMarkService>();
 
var app = builder.Build();
 
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();    
   
} app.MapControllers();
// app.    UseHttpsRedirection();
// GET: /welcome
app.MapGet("/", () =>
{
    return new
    {
        message = "Welcome to the API!",
        status = "Success"
    };
});
app.UseCors("AllowLocalhost");
app.Run();
 