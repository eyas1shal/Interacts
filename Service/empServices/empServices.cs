using eyas_Task4.Service.Cache;
using eyas_Task4.Tabels;
using Microsoft.EntityFrameworkCore;

namespace eyas_Task4.Service.empServices
{
    public class empServices:IempServices
    {
        private readonly ApplicationDbContext _context;
        private readonly ICache _cache;
        public empServices(ApplicationDbContext context, ICache cache)
        {
            _context = context;
            _cache = cache;
        }

        public async Task<List<emp>> GetAll()
        {


            var data = _cache.Get("empList");
            if (data == null)
                _cache.Add("empList", _context.emps.ToList());
            else
            {
                return (List<emp>)data;
            }

            return await _context.emps.ToListAsync();

        }

        public async Task<emp> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void SendMessage(string email)
        {
            Console.WriteLine("the message send to email " + email + " at " + DateTime.Now);
        }
    }
}
