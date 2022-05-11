using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvicSolution.Services.Issue_Request.Dtos.ViewModels.Board
{
    public class BoardViewModel
    {
        public List<Guid> ListStageOrder { get; set; }
        public List<StageViewModel> ListStage { get; set; }

        public BoardViewModel() 
        {
            this.ListStageOrder = new List<Guid>();
            this.ListStage = new List<StageViewModel>();
        }
    }
}
