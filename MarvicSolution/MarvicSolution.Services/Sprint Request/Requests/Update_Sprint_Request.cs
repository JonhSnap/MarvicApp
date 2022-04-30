using System;

namespace MarvicSolution.Services.Sprint_Request.Requests
{
    public class Update_Sprint_Request
    {
        public Guid Id_Project { get; set; }
        public string Sprint_Name { get; set; }
        public string Creator { get; set; }
        public DateTime End_Date { get; set; }
        public DateTime Start_Date { get; set; }
    }
}
