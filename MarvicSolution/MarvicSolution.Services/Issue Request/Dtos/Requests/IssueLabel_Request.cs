using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvicSolution.Services.Issue_Request.Dtos.Requests
{
    public class IssueLabel_Request
    {
        public Guid IdIssue { get; set; }
        public Guid IdLabel { get; set; }
        public IssueLabel_Request()
        {
            IdIssue = Guid.Empty;
            IdLabel = Guid.Empty;
        }
    }
}
