
using eyas_task3.Tables;
using Microsoft.EntityFrameworkCore;

namespace eyas_task3.Services
{
    public class coursesService 
    {

        private readonly ApplicationDbContext _context;

        public coursesService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Tables.Courses>> GetAll()
        {
            return await _context.Courses.ToListAsync();
        }

        public async Task<Tables.Courses?> GetById(int id)
        {
            var obj = await _context.Courses.FirstOrDefaultAsync(c => c.Id == id);
            if (obj == null) { return null; }
            return obj;
        }

    }
}
