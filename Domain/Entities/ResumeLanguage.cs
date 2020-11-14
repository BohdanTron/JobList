namespace JobList.Domain.Entities
{
    public class ResumeLanguage 
    {
        public int Id { get; set; }
        public int ResumeId { get; set; }
        public int LanguageId { get; set; }

        public Resume Resume { get; set; }
    }
}
