using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvicSolution.Services.Project_Resquest.Dtos.Requests
{
    public class SetUserRoleByIdProject_Request
    {
        public Guid IdUser { get; set; }
        public Guid IdProject { get; set; }
        public SetUserRoleByIdProject_Request()
        {
            IdUser = Guid.Empty;
            IdProject = Guid.Empty;
        }

        public SetUserRoleByIdProject_Request(Guid idUser, Guid idProject)
        {
            IdUser = idUser;
            IdProject = idProject;
        }
    }
}
