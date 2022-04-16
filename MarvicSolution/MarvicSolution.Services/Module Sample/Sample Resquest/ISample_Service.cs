
using MarvicSolution.Services.Module_Sample.Dtos;
using MarvicSolution.Services.Module_Sample.Sample_Resquest.Dtos;
using MarvicSolution.Services.Module_Sample.Sample_Resquest.Dtos.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvicSolution.Services.Module_Sample.Sample_Resquest
{
    public interface IIssue_Service
    {
        // INPUT
        Task<int> Create(Issue_CreateRequest request);
        Task<int>  Update(Issue_UpdateRequest request);
        Task<int> Delete(int Id);

        // OUTPUT
        Task<List<Issue_ViewModel>> GetAlls();
        Task<Issue_PageResult<Issue_ViewModel>> GetAllPaging(Get_Sample_PagingRequest request);
    }
}
