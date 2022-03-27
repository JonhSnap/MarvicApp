using MarvicSolution.DATA.EF;
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
    public class SampleService : ISampleService
    {
        private readonly MarvicDbContext _context;
        public SampleService(MarvicDbContext context)
        {
            _context = context;
        }
        public async Task<int> Create(SampleCreateRequest request)
        {
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Update(SampleUpdateRequest request)
        {
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Delete(int Id)
        {
            return await _context.SaveChangesAsync();
        }

        public async Task<Sample_PageResult<SampleViewModel>> GetAllPaging(GetSamplePagingRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<List<SampleViewModel>> GetAlls()
        {
            throw new NotImplementedException();
        }

    }
}
