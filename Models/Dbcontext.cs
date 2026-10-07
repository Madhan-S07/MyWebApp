using Microsoft.EntityFrameworkCore;

namespace MyWebApp.Models;

public class AppDbContext : DbContext
{
    public DbSet<SubjectMark> MarkDetails { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=Models/app.db");
    }
}