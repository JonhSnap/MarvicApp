using System;

namespace MarvicSolution.Services.Issue_Request.Dtos.Requests
{
    public class ChangeIssueSprint_Request
    {
        public Guid IdIssue { get; set; }
        public Guid IdSprint { get; set; }

        public ChangeIssueSprint_Request()
        {
            IdIssue = Guid.Empty;
            IdSprint = Guid.Empty;
        }

    }
}
