using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvicSolution.Services.Sprint_Request.Requests
{
    public class RemoveIssue_Request
    {
        public List<Guid> ListIdIssue { get; set; }
        public RemoveIssue_Request() { }
    }
}
