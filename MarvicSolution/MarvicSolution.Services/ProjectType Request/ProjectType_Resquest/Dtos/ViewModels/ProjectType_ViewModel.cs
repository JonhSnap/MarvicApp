using MarvicSolution.DATA.Entities;
using MarvicSolution.DATA.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvicSolution.Services.ProjectType_Request.ProjectType_Resquest.Dtos.ViewModels
{
    public class ProjectType_ViewModel
    {
        ///Các prop cần thiết cho ViewModel này

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Creator { get; set; }
        public string Updator { get; set; }
        public DateTime UpdateDate { get; set; }
        public EnumStatus IsDeleted { get; set; }

        public ProjectType_ViewModel()
        {

        }

        public ProjectType_ViewModel(ProjectType pt)
        {
            this.Id = pt.Id;
            this.Name = pt.Name;
            this.Creator = pt.Creator;
            this.Updator = pt.Updator;
            this.UpdateDate = pt.UpdateDate;
            this.IsDeleted = pt.IsDeleted;
        }
    }
}
