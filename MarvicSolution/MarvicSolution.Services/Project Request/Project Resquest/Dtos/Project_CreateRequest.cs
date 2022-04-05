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
        [Required(ErrorMessage = "Project name is required.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Key is required.")]
        public string Key { get; set; }
        [Required(ErrorMessage = "Access is required.")]
        public EnumAccess Access { get; set; } = EnumAccess.Public;
        
        public Guid Id_Lead { get; set; } = UserLogin.Id;
        public DateTime? DateStarted { get; set; }
        public DateTime? DateEnd { get; set; }
    }
}
