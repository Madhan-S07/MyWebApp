using Microsoft.EntityFrameworkCore;
using MyWebApp.Models;   // change this to the namespace where AppDbContext and SubjectMark live

namespace MyWebApp.Services
{
    public class SubjectMarkService
    {
        private readonly AppDbContext dbContext;

        public SubjectMarkService(AppDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        // GET all
        public async Task<List<SubjectMark>> GetAllSubjectMarks()
        {
            return await dbContext.MarkDetails.ToListAsync();
        }

        // GET by id
        public async Task<SubjectMark?> GetSubjectmarkbyId(int id)
        {
            return await dbContext.MarkDetails.FindAsync(id);
        }

        // POST
        
    }
}