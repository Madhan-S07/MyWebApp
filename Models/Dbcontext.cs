using Microsoft.EntityFrameworkCore;
using Serilog;
namespace MyWebApp.Models;

public class AppDbContext : DbContext
{
    public DbSet<SubjectMark> MarkDetails { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // optionsBuilder.UseSqlite("Data Source=Models/app.db");
         optionsBuilder.UseSqlite("Data Source=app.db").LogTo(msg => Log.Information($"EF SQL:--{msg}"),
         new[] { DbLoggerCategory.Database.Command.Name}, LogLevel.Information);
    }
}