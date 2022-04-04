using MarvicSolution.DATA.EF;
using MarvicSolution.DATA.Entities;
using MarvicSolution.Services.ProjectType_Request.Dtos;
using MarvicSolution.Services.ProjectType_Request.ProjectType_Resquest.Dtos;
using MarvicSolution.Services.ProjectType_Request.ProjectType_Resquest.Dtos.ViewModels;
using MarvicSolution.Utilities.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarvicSolution.Services.ProjectType_Request.ProjectType_Resquest
{
    public class ProjectType_Service : IProjectType_Service
    {
        private readonly MarvicDbContext _context;
        public ProjectType_Service(MarvicDbContext context)
        {
            _context = context;
        }
        public async Task<Guid> Create(ProjectType_CreateRequest request)
        {
            try
            {
                var projectType = new ProjectType()
                {
                    Id = Guid.NewGuid(),
                    Creator = request.Creator,
                    Name = request.Name,
                    Updator = request.Updator,
                    UpdateDate = request.UpdateDate,
                    IsDeleted = request.IsDeleted
                };

                _context.ProjectTypes.Add(projectType);
                await _context.SaveChangesAsync();
                return projectType.Id;
            }
            catch (Exception e)
            {
                throw new MarvicException($"Error: {e}");
            }
        }

        public async Task<Guid> Update(ProjectType_UpdateRequest request)
        {
            try
            {
                var projectType = _context.ProjectTypes.Find(request.Id);
                projectType.Creator = request.Creator;
                projectType.Name = request.Name;
                projectType.Updator = request.Updator;
                projectType.UpdateDate = request.UpdateDate;

                _context.ProjectTypes.Update(projectType);
                await _context.SaveChangesAsync();
                return projectType.Id;
            }
            catch (Exception e)
            {
                throw new MarvicException($"Error: {e}");
            }
        }

        public async Task<Guid> Delete(Guid Id)
        {
            try
            {
                var projectType = _context.ProjectTypes.Find(Id);
                projectType.IsDeleted = DATA.Enums.EnumStatus.True;
                await _context.SaveChangesAsync();
                return projectType.Id;
            }
            catch (Exception e)
            {
                throw new MarvicException($"Error: {e}");
            }
        }

        public async Task<List<ProjectType_ViewModel>> GetAlls()
        {
            try
            {
                var query = from pt in _context.ProjectTypes select new { pt };
                var data = await query.Select(x => new ProjectType_ViewModel()
                {
                    Id = x.pt.Id,
                    Name = x.pt.Name,
                    Creator = x.pt.Creator,
                    Updator = x.pt.Updator,
                    UpdateDate = x.pt.UpdateDate,
                    IsDeleted = x.pt.IsDeleted,
                }).ToListAsync();
                return data;
            }
            catch (NullReferenceException e)
            {
                throw new MarvicException($"Error: {e}");
            }
        }

        Task<ProjectType_PageResult<ProjectType_ViewModel>> IProjectType_Service.GetAllPaging(Get_ProjectType_PagingRequest request)
        {
            throw new NotImplementedException();
        }


    }
}
