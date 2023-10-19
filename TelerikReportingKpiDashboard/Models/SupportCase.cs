namespace TelerikReportingKpiDashboard.Models
{
    namespace SupportKpiDashboard.Models
    {
        public class SupportCase
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Group { get; set; }
            public DateTime Start { get; set; }
            public DateTime End { get; set; }
            public int Rating { get; set; }

        }

    }

}
