namespace ReportWebApi.Models
{
    public class ReportItem
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public string Body { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime LastModifiedDate { get; set; }

        public int CategoryId { get; set; }

        public string CreationEmail { get; set; }   

        public Boolean IsPublished { get; set; }
    }
}
