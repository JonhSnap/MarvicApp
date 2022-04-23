using MarvicSolution.DATA.Common;
using MarvicSolution.DATA.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvicSolution.Services.Project_Request.Project_Resquest.Dtos
{
    public class Project_CreateRequest
    {
        public string Name { get; set; }
        public string Key { get; set; }
        public EnumAccess Access { get; set; } = EnumAccess.Public;
        
        public Guid Id_Lead { get; set; } = UserLogin.Id;
        public DateTime DateStarted { get; set; }
        public DateTime DateEnd { get; set; }
    }
}
