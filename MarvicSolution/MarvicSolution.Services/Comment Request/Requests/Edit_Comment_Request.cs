using System;

namespace MarvicSolution.Services.Comment_Request.Requests
{
    public class Edit_Comment_Request
    {
        public Guid Id_User { get; set; }
        public string Content { get; set; }
    }
}
