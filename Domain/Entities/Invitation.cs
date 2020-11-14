namespace JobList.Domain.Entities
{
    public class Invitation
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int VacancyId { get; set; }

        public Employee Employee { get; set; }
        public Vacancy Vacancy { get; set; }
    }
}
