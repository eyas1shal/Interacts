using eyas_Task4.Tabels;
using Microsoft.EntityFrameworkCore;

namespace eyas_Task4.Service.etsService
{
    public class etsService : IetsService
    {

        private readonly ApplicationDbContext _context;

        async Task<EmpTransSalary> IetsService.addSalary(EmpTransSalary record)
        {
            {
                var obj = new EmpTransSalary()
                {
                    Id = record.Id,
                    EmpId = record.EmpId,
                    SalaryDate = record.SalaryDate,
                    month = record.month
                };
                await _context.empTransSalaries.AddAsync(obj);

                await _context.SaveChangesAsync();

                return obj;
            }
        }
    }
}
