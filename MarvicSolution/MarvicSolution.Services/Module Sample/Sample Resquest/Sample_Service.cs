using MarvicSolution.DATA.EF;
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
    public class Sample_Service : ISample_Service
    {
        private readonly MarvicDbContext _context;
        public Sample_Service(MarvicDbContext context)
        {
            _context = context;
        }
        public async Task<int> Create(Sample_CreateRequest request)
        {
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Update(Sample_UpdateRequest request)
        {
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Delete(int Id)
        {
            return await _context.SaveChangesAsync();
        }

        public async Task<Sample_PageResult<Sample_ViewModel>> GetAllPaging(Get_Sample_PagingRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Sample_ViewModel>> GetAlls()
        {
            throw new NotImplementedException();
        }

    }
}
