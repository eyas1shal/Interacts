namespace eyas_task3.Services
{
    public interface IcoursesService
    {
        Task<List<Tables.Student>> GetAll();
        Task<Tables.Student> GetById(int id);
    }
}
