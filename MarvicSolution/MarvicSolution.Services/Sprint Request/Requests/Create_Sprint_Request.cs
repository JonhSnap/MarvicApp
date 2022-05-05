using System;

namespace MarvicSolution.Services.Sprint_Request.Requests
{
    public class Create_Sprint_Request
    {
        public Guid Id_Project { get; set; }
        public string Sprint_Name { get; set; }
        public Guid Id_Creator { get; set; }
    }
}
