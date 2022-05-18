using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvicSolution.Services.Issue_Request.Dtos.ViewModels.Board
{
    public class ListGroupByAssignee
    {
        public List<Guid?> ListIdAssignee { get; set; }
        public List<Assignee> ListAssignee { get; set; }
        public ListGroupByAssignee()
        {
            this.ListIdAssignee = new List<Guid?>();
            this.ListAssignee = new List<Assignee>();
        }

        public ListGroupByAssignee(List<Guid?> idAssignee, List<Assignee> listGroup)
        {
            ListIdAssignee = idAssignee;
            ListAssignee = listGroup;
        }
    }
}
