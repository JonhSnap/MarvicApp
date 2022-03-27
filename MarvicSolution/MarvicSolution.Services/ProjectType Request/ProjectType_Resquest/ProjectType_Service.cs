using MarvicSolution.DATA.EF;
using MarvicSolution.DATA.Entities;
using MarvicSolution.Services.Group_Sample.Dtos;
using MarvicSolution.Services.Group_Sample.Module_Sample.Dtos;
using MarvicSolution.Services.Group_Sample.Module_Sample.Dtos.ViewModels;
using MarvicSolution.Services.ProjectType_Request.Dtos;
using MarvicSolution.Services.ProjectType_Request.ProjectType_Resquest.Dtos;
using MarvicSolution.Services.ProjectType_Request.ProjectType_Resquest.Dtos.ViewModels;
using MarvicSolution.Utilities.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        public async Task<int> Create(ProjectType_CreateRequest request)
        {
            var projectType = new ProjectType()
            {
                Creator = request.Creator,
                Name = request.Name,
                Updator = request.Updator,
                UpdateDate = request.UpdateDate,
                IsDeleted = request.IsDeleted
            };

            _context.ProjectTypes.Add(projectType);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Update(ProjectType_UpdateRequest request)
        {
            var projectType = _context.ProjectTypes.Find(request.Id);
            if (projectType == null)
                throw new MarvicException($"Can not find a project: {request.Id}");

            projectType.Creator = request.Creator;
            projectType.Name = request.Name;
            projectType.Updator = request.Updator;
            projectType.UpdateDate = request.UpdateDate;

            _context.ProjectTypes.Add(projectType);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Delete(int Id)
        {
            var projectType = _context.ProjectTypes.Find(Id);
            if (projectType == null)
                throw new MarvicException($"Can not find a project: {Id}");

            projectType.IsDeleted = DATA.Enums.EnumStatus.True;
            return await _context.SaveChangesAsync();
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
            return null;
        }

        Task<ProjectType_PageResult<ProjectType_ViewModel>> IProjectType_Service.GetAllPaging(Get_ProjectType_PagingRequest request)
        {
            throw new NotImplementedException();
        }


    }
}
