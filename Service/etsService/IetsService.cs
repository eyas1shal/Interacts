using eyas_Task4.Tabels;

namespace eyas_Task4.Service.etsService
{
    public interface IetsService
    {
        Task<EmpTransSalary> addSalary(EmpTransSalary model);
    }
}
