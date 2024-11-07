namespace DateTimeApp.Models
{
    public class DateTimeRecord
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public required string Description { get; set; }
    }
}
