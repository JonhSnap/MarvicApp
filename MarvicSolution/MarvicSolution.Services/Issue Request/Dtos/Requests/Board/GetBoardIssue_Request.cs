using MarvicSolution.DATA.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvicSolution.Services.Issue_Request.Dtos.Requests.Board
{
    public class GetBoardIssue_Request
    {
        public Guid IdSprint { get; set; }
        public Guid Epic { get; set; }
        public EnumIssueType Type { get; set; }
        public GetBoardIssue_Request()
        {
            this.IdSprint = Guid.Empty;
            this.Epic = Guid.Empty;
            this.Type = 0;
        }

        public GetBoardIssue_Request(Guid idSprint, Guid epic, EnumIssueType type)
        {
            IdSprint = idSprint;
            Epic = epic;
            Type = type;
        }
    }
}
