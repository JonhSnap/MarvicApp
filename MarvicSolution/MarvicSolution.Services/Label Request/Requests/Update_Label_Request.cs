using System;

namespace MarvicSolution.Services.Label_Request.Requests
{
    public class Update_Label_Request
    {
        public string Name { get; set; }
        public Guid Id_Updator { get; set; }
    }
}
