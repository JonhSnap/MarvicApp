using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvicSolution.Services.Issue_Request.Dtos.Requests
{
    public class StatisticIssue_Request
    {
        public Guid idProject { get; set; }
        public DateTime DateStarted { get; set; }
        public DateTime DateEnd { get; set; }
        public StatisticIssue_Request()
        {
            idProject = Guid.Empty;
            DateStarted = new DateTime();
            DateEnd = new DateTime();
        }
    }
}
