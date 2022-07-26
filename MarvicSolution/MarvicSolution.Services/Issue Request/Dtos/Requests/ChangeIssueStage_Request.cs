using System;

namespace MarvicSolution.Services.Issue_Request.Dtos.Requests
{
    public class ChangeIssueStage_Request
    {
        public Guid IdUpdator { get; set; }
        public Guid IdIssue { get; set; }
        public Guid IdStage { get; set; }
        public int Order { get; set; }
        public ChangeIssueStage_Request()
        {
            IdUpdator = Guid.NewGuid();
            IdIssue = Guid.NewGuid();
            IdStage = Guid.NewGuid();
            Order = 0;
        }
    }
}
