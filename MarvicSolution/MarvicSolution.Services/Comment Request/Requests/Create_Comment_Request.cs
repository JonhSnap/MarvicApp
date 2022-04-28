using System;

namespace MarvicSolution.Services.Comment_Request.Requests
{
    public class Create_Comment_Request
    {
        public Guid Id_Issue { get; set; }
        public Guid Id_User { get; set; }
        public string Content { get; set; }
        public Guid Id_ParentComment { get; set; }
    }
}
