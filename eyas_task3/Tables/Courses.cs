namespace eyas_task3.Tables
{
    public class Courses
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<StC> StCs { get; set; }


    }
}
