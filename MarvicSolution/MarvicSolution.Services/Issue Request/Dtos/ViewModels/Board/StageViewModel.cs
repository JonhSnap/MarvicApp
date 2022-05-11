using MarvicSolution.Services.Issue_Request.Issue_Request.Dtos.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvicSolution.Services.Issue_Request.Dtos.ViewModels.Board
{
    public class StageViewModel
    {
        public Guid? Id { get; set; }
        public Guid? Id_Project { get; set; }
        public string Stage_Name { get; set; }
        public Guid Id_Creator { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime UpdateDate { get; set; }
        public int Order { get; set; }
        public List<Guid> ListIssueOrder { get; set; }
        public List<Issue_ViewModel> ListIssue { get; set; }

        public StageViewModel(Guid? id, Guid? id_Project, string stage_Name, Guid id_Creator, DateTime dateCreated, DateTime updateDate, int order)
        {
            Id = id;
            Id_Project = id_Project;
            Stage_Name = stage_Name;
            Id_Creator = id_Creator;
            DateCreated = dateCreated;
            UpdateDate = updateDate;
            Order = order;
            ListIssueOrder = new List<Guid>();
            ListIssue = new List<Issue_ViewModel>();
        }

        public StageViewModel() 
        {
            this.Id = Guid.Empty;
            this.Id_Project = Guid.Empty;
            this.Stage_Name = string.Empty;
            this.Id_Creator = Guid.Empty; ;
            this.DateCreated = new DateTime();
            this.UpdateDate = new DateTime();
            this.Order = 0;
            this.ListIssueOrder = new List<Guid>();
            this.ListIssue = new List<Issue_ViewModel>();
        }

    }
}
