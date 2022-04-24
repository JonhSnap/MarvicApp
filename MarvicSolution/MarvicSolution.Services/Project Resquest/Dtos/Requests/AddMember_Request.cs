using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvicSolution.Services.Project_Request.Project_Resquest.Dtos
{
    public class AddMember_Request
    {
        public Guid IdProject { get; set; }
        public List<string> UserNames { get; set; }
    }
}
