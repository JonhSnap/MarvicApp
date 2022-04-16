using MarvicSolution.DATA.EF;
using MarvicSolution.Services.Issue_Request.Issue_Request.Dtos;
using MarvicSolution.Services.Issue_Request.Issue_Request.Dtos.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvicSolution.Services.Issue_Request.Issue_Request
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


        public async Task<List<Issue_ViewModel>> GetAlls()
        {
            throw new NotImplementedException();
        }

    }
}
