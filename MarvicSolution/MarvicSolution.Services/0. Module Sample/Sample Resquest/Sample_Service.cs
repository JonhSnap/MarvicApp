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
    public class Issue_Service : IIssue_Service
    {
        private readonly MarvicDbContext _context;
        public Issue_Service(MarvicDbContext context)
        {
            _context = context;
        }
        public async Task<int> Create(Issue_CreateRequest request)
        {
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Update(Issue_UpdateRequest request)
        {
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Delete(int Id)
        {
            return await _context.SaveChangesAsync();
        }

        public async Task<Issue_PageResult<Issue_ViewModel>> GetAllPaging(Get_Sample_PagingRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Issue_ViewModel>> GetAlls()
        {
            throw new NotImplementedException();
        }

    }
}
