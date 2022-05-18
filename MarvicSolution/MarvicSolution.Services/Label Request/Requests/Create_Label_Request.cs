using System;

namespace MarvicSolution.Services.Label_Request.Requests
{
    public class Create_Label_Request
    {
        public Guid Id_Project { get; set; }
        public string Name { get; set; }
        public Guid Id_Creator { get; set; }
    }
}
