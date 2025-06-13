namespace WebApplication3.Models
{
    public class AssignmentPerService
    {
        public string ServiceCode { get; set; } = string.Empty;
        public string ServiceName { get; set; } = string.Empty;
        public int TotalAssigned { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public int Week { get; set; }
    }
}
