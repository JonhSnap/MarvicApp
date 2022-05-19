using MarvicSolution.Services.Issue_Request.Issue_Request.Dtos.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvicSolution.Services.Issue_Request.Dtos.ViewModels.Board
{
    public class BoardViewModel
    {
        public List<Guid?> ListStageOrder { get; set; }
        public List<StageViewModel> ListStage { get; set; }
        public List<int> ListType { get; set; }
        public List<Issue_ViewModel> ListEpic { get; set; }


        public BoardViewModel()
        {
            this.ListStageOrder = new List<Guid?>();
            this.ListStage = new List<StageViewModel>();
            this.ListType = new List<int>() { 2, 3, 4 };
            this.ListEpic = new List<Issue_ViewModel>();
        }
    }
}
