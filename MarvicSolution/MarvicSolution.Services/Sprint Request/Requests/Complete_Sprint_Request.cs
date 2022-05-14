using System;

namespace MarvicSolution.Services.Sprint_Request.Requests
{
    public class Complete_Sprint_Request
    {
        public Guid CurrentProjectId { get; set; }
        public Guid CurrentSprintId { get; set; }
        public Guid NewSprintId { get; set; }
    }
}
