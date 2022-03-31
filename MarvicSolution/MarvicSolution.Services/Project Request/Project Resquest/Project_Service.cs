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

        // GetAlls Linq
        public async Task<List<Project_ViewModel>> GetAlls_Linq()
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

        // T-script
        public async Task<List<Project_ViewModel>> GetAlls_Tscript()
        {
            try
            {
                var data = await _context.Projects.FromSqlInterpolated($"Select * from Project").Select(x => new Project_ViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Key = x.Key
                }).ToListAsync();

                return data;
            }
            catch (Exception e)
            {
                throw new MarvicException($"Error: {e}");
            }
        }

        // Proc
        public async Task<List<Project_ViewModel>> GetAlls_Proc()
        {
            try
            {
                var proc = await _context.Projects.FromSqlInterpolated($"exec [dbo].[GetAlls_Proc]")
                    .ToListAsync();
                var data = proc.Select(x => new Project_ViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Key = x.Key
                }).ToList();

                return data;
            }
            catch (Exception e)
            {
                throw new MarvicException($"Error: {e}");
            }
        }

        // T-script
        public async Task<List<Project_ViewModel>> Groupby_ProjectType_Tscript()
        {
            try
            {
                var data = await _context.Projects.
                    FromSqlRaw("SELECT *FROM Project WHERE ProjectType_Id = '77b88991-f823-4301-b452-1b14ca44d5cb' ")
                    .Select(x => new Project_ViewModel()
                    {
                        Id = x.Id,
                        Name = x.Name,
                        Key = x.Key
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
