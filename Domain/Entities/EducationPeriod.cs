using System;

namespace JobList.Domain.Entities
{
    public class EducationPeriod 
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
        public int ResumeId { get; set; }
        public int SchoolId { get; set; }
        public int FacultyId { get; set; }        

        public Resume Resume { get; set; }
        public School School { get; set; }
        public Faculty Faculty { get; set; }
    }
}
