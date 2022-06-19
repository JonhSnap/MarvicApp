using MarvicSolution.DATA.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvicSolution.Services.Project_Resquest.Dtos.Requests
{
    public class UpdateStarredProject_Request
    {
        public Guid IdProject { get; set; }
        public UpdateStarredProject_Request()
        {
            IdProject = Guid.Empty;
        }
    }
}
