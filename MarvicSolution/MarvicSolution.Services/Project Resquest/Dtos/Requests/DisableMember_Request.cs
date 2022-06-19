﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvicSolution.Services.Project_Resquest.Dtos.Requests
{
    public class DisableMember_Request
    {
        public Guid IdUser { get; set; }
        public Guid IdProject { get; set; }

        public DisableMember_Request()
        {
            IdUser = Guid.Empty;
            IdProject = Guid.Empty;
        }
    }
}
