namespace eyas_task3.Tables
{
    public class Student
    {


        public int Id { get; set; }

        public required string Name { get; set; }

        public ICollection<StC> StCs { get; set; }
    }
}
