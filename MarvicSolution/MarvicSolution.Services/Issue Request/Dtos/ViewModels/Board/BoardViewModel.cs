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
        public IList<Guid> ListStageOrder { get; set; }
        public IList<StageViewModel> ListStage { get; set; }
        public IList<int> ListType { get; set; }
        public IList<Issue_ViewModel> ListEpic { get; set; }


        public BoardViewModel()
        {
            this.ListStageOrder = new List<Guid>();
            this.ListStage = new List<StageViewModel>();
            this.ListType = new List<int>() { 2, 3, 4 };
            this.ListEpic = new List<Issue_ViewModel>();
        }

        public BoardViewModel(IList<Guid> listStageOrder, IList<StageViewModel> listStage, IList<int> listType, IList<Issue_ViewModel> listEpic)
        {
            ListStageOrder = listStageOrder;
            ListStage = listStage;
            ListType = listType;
            ListEpic = listEpic;
        }
    }
}
