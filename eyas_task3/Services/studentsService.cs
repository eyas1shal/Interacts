using Microsoft.EntityFrameworkCore;

namespace eyas_task3.Services
{
    public class studentsService
    {
        private readonly ApplicationDbContext _context;

        public studentsService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Tables.Student>> GetAll()
        {
            return await _context.Students.ToListAsync();
        }   

        public async Task<Tables.Student?> GetById(int id)
        {
            var obj = await _context.Students.FirstOrDefaultAsync(c => c.Id == id);
            if(obj == null) { return null; }
            return obj;
        }
    }
}
