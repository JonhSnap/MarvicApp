using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvicSolution.Services.Issue_Request.Dtos.Requests
{
    public class GetIssueByParentRequest
    {
        public Guid IdProject { get; set; }
        public Guid IdParent { get; set; }
    }
}
