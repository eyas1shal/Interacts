namespace eyas_task3.Services
{
    public interface istudentsService
    {
        Task<List<Tables.Student>> GetAll();
        Task<Tables.Student> GetById(int id);
    }
}
