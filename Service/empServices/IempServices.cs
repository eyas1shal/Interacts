using eyas_Task4.Tabels;

namespace eyas_Task4.Service.empServices
{
    public interface IempServices
    {
        Task<List<emp>> GetAll();
        Task<emp> GetById(int id);

        void SendMessage(string email);

    }
}
