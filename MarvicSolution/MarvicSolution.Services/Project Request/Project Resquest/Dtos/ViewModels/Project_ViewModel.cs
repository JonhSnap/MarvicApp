using MarvicSolution.DATA.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvicSolution.Services.Project_Request.Project_Resquest.Dtos.ViewModels
{
    public class Project_ViewModel
    {
        ///Các prop cần thiết cho ViewModel này
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Key { get; set; }
        public EnumAccess Access { get; set; } = EnumAccess.Public;
    }
}
