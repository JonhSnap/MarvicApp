using MarvicSolution.DATA.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvicSolution.Services.Sprint_Request.Requests
{
    public class AddIssue_Request
    {
        public Guid IdSprint { get; set; }
        public Guid IdIssue { get; set; }
        public AddIssue_Request() { }
    }
}
