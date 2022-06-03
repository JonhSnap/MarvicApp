using MarvicSolution.DATA.Common;
using System;

namespace MarvicSolution.Services.Issue_Request.Dtos.Requests
{
    public class ChangeStage_Request
    {
        public Guid IdUpdator { get; set; }
        public Guid IdIssue { get; set; }
        public Guid IdStage { get; set; }
        public ChangeStage_Request()
        {
            IdUpdator = Guid.NewGuid();
            IdIssue = Guid.NewGuid();
            IdStage = Guid.NewGuid();
        }
    }
}
