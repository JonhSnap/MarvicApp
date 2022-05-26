using System;

namespace MarvicSolution.Services.Stage_Request.Requests
{
    public class Drop_Stage_Request
    {
        public int CurrentPos { get; set; }
        public int NewPos { get; set; }
        public Guid Id_Project { get; set; }
    }
}
