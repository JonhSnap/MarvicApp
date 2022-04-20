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
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Key { get; set; }
        public EnumAccess Access { get; set; } = EnumAccess.Public;
        public string Lead { get; set; }
        public Guid Id_Creator { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime? DateStarted { get; set; }
        public DateTime? DateEnd { get; set; }

        public Guid Id_Updator { get; set; }
        public DateTime? UpdateDate { get; set; }
        public EnumStatus IsStared { get; set; } = EnumStatus.False;
        public EnumStatus IsDeleted { get; set; } = EnumStatus.False;


    }
}
