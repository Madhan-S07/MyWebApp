var builder = WebApplication.CreateBuilder(args);
 
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
 
app.Run();
 