using System;

namespace MarvicSolution.Services.Stage_Request.Requests
{
    public class Update_Stage_Request
    {
        public string Stage_Name { get; set; }
        public Guid Id_Updator { get; set; }
        public int Order { get; set; }
    }
}
