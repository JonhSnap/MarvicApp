using System;

namespace MarvicSolution.Services.Stage_Request.Requests
{
    public class Create_Stage_Request
    {
        public Guid Id_Project { get; set; }
        public string Stage_Name { get; set; }
        public Guid Id_Creator { get; set; }
    }
}
