using MarvicSolution.DATA.EF;
using MarvicSolution.Services.Project_Request.Dtos;
using MarvicSolution.Services.Project_Request.Project_Resquest.Dtos;
using MarvicSolution.Services.Project_Request.Project_Resquest.Dtos.ViewModels;
using MarvicSolution.Utilities.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvicSolution.Services.Project_Request.Project_Resquest
{
    public class Project_Service : IProject_Service
    {
        private readonly MarvicDbContext _context;
        public Project_Service(MarvicDbContext context)
        {
            _context = context;
        }
        public async Task<int> Create(Project_CreateRequest request)
        {

            return await _context.SaveChangesAsync();
        }

        public async Task<int> Update(Project_UpdateRequest request)
        {
            return await _context.SaveChangesAsync();
        }

        public async Task<Guid> Delete(Guid Id)
        {
            await _context.SaveChangesAsync();
            return Id;
        }

        public async Task<Project_PageResult<Project_ViewModel>> GetAllPaging(Get_Project_PagingRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Project_ViewModel>> GetAlls()
        {
            try
            {
                var query = from proj in _context.Projects select new { proj };
                var data = await query.Select(x => new Project_ViewModel()
                {
                    Id = x.proj.Id,
                    Name = x.proj.Name,
                    Key = x.proj.Key
                }).ToListAsync();
                return data;
            }
            catch (NullReferenceException e)
            {
                throw new MarvicException($"Error: {e}");
            }
        }

    }
}
