namespace eyas_task3.Services
{
    public interface IstcServices
    {
        Task<List<Tables.Student>> GetAll();
        Task<Tables.Student> GetByStudentId(int id);
        Task<Tables.Student> GetByCourseId(int id);

    }
}
