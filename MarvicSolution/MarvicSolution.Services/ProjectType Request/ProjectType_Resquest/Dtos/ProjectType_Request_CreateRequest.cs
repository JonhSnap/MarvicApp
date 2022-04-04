using MarvicSolution.DATA.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvicSolution.Services.ProjectType_Request.ProjectType_Resquest.Dtos.ViewModels
{
    public class ProjectType_CreateRequest
    {
        ///Các prop cần thiết cho request này
        [DefaultValue("00000000-0000-0000-0000-000000000000")]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Creator { get; set; }
        public string Updator { get; set; }
        public DateTime UpdateDate { get; set; }
        [DefaultValue(0)]
        public EnumStatus IsDeleted { get; set; }
    }
}
