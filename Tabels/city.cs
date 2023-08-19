namespace eyas_Task4.Tabels
{
    public class city
    {

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<emp> emps { get; set; }

    }
}
