using System;

namespace MarvicSolution.Services.Issue_Request.Dtos.Requests
{
    public class ChangeStage_Request
    {
        public Guid IdIssue { get; set; }
        public Guid IdStage { get; set; }
    }
}
