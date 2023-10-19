using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TelerikReportingKpiDashboard.Models.SupportKpiDashboard.Models;

namespace TelerikReportingKpiDashboard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupportCasesController : ControllerBase
    {
        // GET: api/<SupportCasesController>
        [HttpGet]
        public IEnumerable<SupportCase> Get()
        {
            var rand = new Random();

            DateTime _start;
            DateTime _end;

            return Enumerable.Range(0, 50).Select(index => new SupportCase
            {
                Id = index,
                Name = "Employee " + index.ToString(),
                Group = getSupportGroup(index),
                Start = (_start = DateTime.Now.AddHours(rand.Next(-6, 0))),
                End = (_end = DateTime.Now.AddHours(rand.Next(8, 28) - (((index % 5) * 2)))),
                Rating = getSupportRating(_start, _end)
            }).ToList();
        }

        private string getSupportGroup(int index)
        {
            string group = "";

            switch (index % 5)
            {
                case 0: group = "A"; break;
                case 1: group = "B"; break;
                case 2: group = "C"; break;
                case 3: group = "D"; break;
                case 4: group = "E"; break;
            }
            return group;
        }

        private int getSupportRating(DateTime start, DateTime end)
        {
            TimeSpan timeToReply = end - start;

            int rating;

            switch (timeToReply.TotalHours)
            {
                case < 4: rating = 5; break;
                case < 8: rating = 4; break;
                case < 16: rating = 3; break;
                case < 24: rating = 2; break;
                default: rating = 1; break;
            }
            return rating;
        }
    }
}
