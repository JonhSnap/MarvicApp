using MarvicSolution.DATA.EF;
using MarvicSolution.DATA.Entities;
using MarvicSolution.Services.Group_Sample.Dtos;
using MarvicSolution.Services.Group_Sample.Module_Sample.Dtos;
using MarvicSolution.Services.Group_Sample.Module_Sample.Dtos.ViewModels;
using MarvicSolution.Services.ProjectType_Request.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvicSolution.Services.ProjectType_Request.ProjectType_Resquest.Dtos.ViewModels
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
            projectType = new ProjectType()
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

        public async Task<int> Delete(int Id)
        {
            var projectType = _context.ProjectTypes.Find(Id);
            projectType = new ProjectType()
            {
                IsDeleted = DATA.Enums.EnumStatus.True
            };

            return await _context.SaveChangesAsync();
        }

        public async Task<List<ProjectType_ViewModel>> GetAlls()
        {
            var output = from pt in _context.ProjectTypes.ToList()
                         select new ProjectType_ViewModel(pt);

            return output.ToList();
        }

        Task<ProjectType_PageResult<ProjectType_ViewModel>> IProjectType_Service.GetAllPaging(Get_ProjectType_PagingRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
