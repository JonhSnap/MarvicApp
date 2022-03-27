using MarvicSolution.Services.Group_Sample.Dtos;
using MarvicSolution.Services.Group_Sample.Module_Sample.Dtos;
using MarvicSolution.Services.Group_Sample.Module_Sample.Dtos.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvicSolution.Services.Group_Sample.Module_Sample
{
    public interface ISampleService
    {
        Task<int> Create(SampleCreateRequest request);
        Task<int>  Update(SampleUpdateRequest request);
        Task<int> Delete(int Id);

        Task<List<SampleViewModel>> GetAlls();
        Task<Sample_PageResult<SampleViewModel>> GetAllPaging(GetSamplePagingRequest request);
    }
}
