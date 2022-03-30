
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
    public interface ISample_Service
    {
        // INPUT
        Task<int> Create(Sample_CreateRequest request);
        Task<int>  Update(Sample_UpdateRequest request);
        Task<int> Delete(int Id);

        // OUTPUT
        Task<List<Sample_ViewModel>> GetAlls();
        Task<Sample_PageResult<Sample_ViewModel>> GetAllPaging(Get_Sample_PagingRequest request);
    }
}
