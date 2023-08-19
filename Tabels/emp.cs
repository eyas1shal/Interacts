namespace eyas_Task4.Tabels
{
    public class emp
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string age { get; set; }
        public int cityId { get; set; }

        public city city { get; set; }
        public ICollection<EmpTransSalary> ets { get; set;}

    }
}
