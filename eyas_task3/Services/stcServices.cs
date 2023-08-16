using Microsoft.EntityFrameworkCore;

namespace eyas_task3.Services
{
    public class stcServices
    {


        private readonly ApplicationDbContext _context;

        public stcServices(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Tables.StC>> GetAll()
        {
            return await _context.StCs.ToListAsync();
        }

        public async Task<Tables.StC?> GetByStudentId(int id)
        {
            var obj = await _context.StCs.FirstOrDefaultAsync(c => c.StId == id);
            if (obj == null) { return null; }
            return obj;
        }
        
        public async Task<Tables.StC?> GetByCourseId(int id)
        {
            var obj = await _context.StCs.FirstOrDefaultAsync(c => c.CId == id);
            if (obj == null) { return null; }
            return obj;
        }

    }
}
