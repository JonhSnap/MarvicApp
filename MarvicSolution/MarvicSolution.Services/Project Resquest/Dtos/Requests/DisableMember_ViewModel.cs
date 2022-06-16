using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvicSolution.Services.Project_Resquest.Dtos.Requests
{
    public class DisableMember_ViewModel
    {
        public List<Guid> ListIdUser { get; set; }
        public Guid IdProject { get; set; }

        public DisableMember_ViewModel()
        {
            ListIdUser = new List<Guid>();
            IdProject = Guid.Empty;
        }
    }
}
