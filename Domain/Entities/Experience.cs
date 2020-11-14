using System;

namespace JobList.Domain.Entities
{
    public class Experience 
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string Position { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? FinishDate { get; set; }
        public int ResumeId { get; set; }

        public Resume Resume { get; set; }
    }
}
