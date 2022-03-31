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
        ///Các prop cần thiết cho request này
        ///public Guid Id { get; set; }
        [Required(ErrorMessage = "Project name is required.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Key is required.")]
        public string Key { get; set; }
        [Required(ErrorMessage = "ProjectType Id Key is required.")]
        public Guid Id_ProjectType { get; set; }
        public Guid Id_Lead { get; set; }
        public Guid Id_Creator { get; set; }

        public DateTime? DateStarted { get; set; }
        public DateTime? DateEnd { get; set; }

        public EnumStatus IsDeleted { get; set; }
    }
}
