using MarvicSolution.DATA.Common;
using MarvicSolution.DATA.EF;
using MarvicSolution.DATA.Entities;
using MarvicSolution.DATA.Enums;
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
        public async Task<Guid> Create(Project_CreateRequest rq)
        {
            try
            {
                var id = UserLogin.Id;
                var proj = new Project()
                {
                    Id = Guid.NewGuid(),
                    Name = rq.Name,
                    Key = rq.Key,
                    Access = rq.Access,
                    Id_Lead = rq.Id_Lead.Equals(Guid.Empty) ? UserLogin.Id : rq.Id_Lead,
                    Id_Creator = UserLogin.Id,
                    DateCreated = DateTime.Now,
                    DateStarted = rq.DateStarted,
                    DateEnd = rq.DateEnd
                };

                _context.Projects.Add(proj);
                await _context.SaveChangesAsync();
                return proj.Id;
            }
            catch (Exception e)
            {
                throw new MarvicException($"Error: {e}");
            }
        }
        public Project_ViewModel GetProjectById(Guid Id)
        {
            try
            {
                var proj = _context.Projects.FirstOrDefault(p => p.Id.Equals(Id) && p.IsDeleted == EnumStatus.False);
                if (proj == null)
                    throw new MarvicException($"Cannot find the project with id: {Id}");
                var result = new Project_ViewModel()
                {
                    Id = proj.Id,
                    Name = proj.Name,
                    Key = proj.Key,
                    Access = proj.Access
                };
                return result;
            }
            catch (Exception e)
            {
                throw new MarvicException($"Error: {e}");
            }
        }

        public async Task<Guid> Update(Project_UpdateRequest rq)
        {
            try
            {
                var proj = _context.Projects.Find(rq.Id);
                if (proj == null)
                    throw new MarvicException($"Cannot find the project with id: {rq.Id}");
                proj.Name = rq.Name;
                proj.Key = rq.Key;
                proj.Access = rq.Access;
                proj.Id_Lead = rq.Id_Lead;
                proj.DateStarted = rq.DateStarted;
                proj.DateEnd = rq.DateEnd;
                proj.Id_Updator = UserLogin.Id;
                proj.UpdateDate = DateTime.Now;
                proj.IsStared = rq.IsStared;

                await _context.SaveChangesAsync();
                return rq.Id;
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
                var proj = _context.Projects.Find(Id);
                proj.IsDeleted = EnumStatus.True;
                await _context.SaveChangesAsync();
                return Id;
            }
            catch (Exception e)
            {
                throw new MarvicException($"Error: {e}");
            }
        }

        public async Task<Project_PageResult<Project_ViewModel>> GetAllPaging(Get_Project_PagingRequest rq)
        {
            throw new NotImplementedException();
        }

        // GetAlls Linq
        public async Task<List<Project_ViewModel>> GetAlls()
        {
            try
            {
                var query = from proj in _context.Projects select new { proj };
                var data = await query.Where(d => d.proj.IsDeleted == EnumStatus.False).Select(x => new Project_ViewModel()
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
                var data = await _context.Projects.FromSqlInterpolated($"Select * from Project Where Project.IsDelete = 0").Select(x => new Project_ViewModel()
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
        public async Task<List<Project_ViewModel>> Groupby_ProjectType_Tscript(Guid projType_Id)
        {
            try
            {
                var data = await _context.Projects.
                    FromSqlInterpolated($"SELECT *FROM Project WHERE ProjectType_Id = {projType_Id}")
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

        public List<Project_ViewModel> GetProjectByIdUser(Guid IdUser)
        {
            try
            {
                var projects = from mem in _context.Members
                               join u in _context.App_Users on mem.Id_User equals u.Id
                               join p in _context.Projects on mem.Id_Project equals p.Id
                               where mem.Id_User.Equals(IdUser) && p.IsDeleted.Equals(EnumStatus.False)
                               select new Project_ViewModel
                               {
                                   Id = p.Id,
                                   Name = p.Name,
                                   Key = p.Key,
                                   Access = p.Access
                               };
                return projects.ToList();
            }
            catch (Exception e)
            {
                throw new MarvicException($"Error: {e}");
            }
        }

        public Guid GetIdUserByUserName(string userName)
        {
            try
            {
                return _context.App_Users.FirstOrDefault(u => u.UserName.Equals(userName) && u.IsDeleted.Equals(EnumStatus.False)).Id;
            }
            catch (Exception e)
            {
                throw new MarvicException($"Error: {e}");
            }
        }

        public Guid AddMembers(Guid IdProject, List<string> userNames)
        {
            try
            {
                foreach (var i_name in userNames)
                {
                    Member member = new Member { Id_Project = IdProject, Id_User = GetIdUserByUserName(i_name) };
                    _context.Members.Add(member);
                }

                _context.SaveChanges();
                return IdProject;
            }
            catch (Exception e)
            {
                throw new MarvicException($"Error: {e}");
            }
        }

        public List<Guid> Get_IdMembers_By_IdProject(Guid IdProject)
        {
            return _context.Members.Where(
                                            m => m.Id_Project.Equals(IdProject)
                                            && m.IsDeleted.Equals(EnumStatus.False)
                                        ).Select(m => m.Id_User).ToList();
        }

        public List<Guid> Get_All_IdMembers()
        {
            try
            {
                return _context.Members.Where(m => m.IsDeleted.Equals(EnumStatus.False))
                                        .Select(m => m.Id_User).ToList();
            }
            catch (Exception e)
            {
                throw new MarvicException($"Error: {e}");
            }
        }

        public List<string> Get_UserNames_By_Ids(List<Guid> ListIdMember)
        {
            try
            {
                List<string> listUserName = new List<string>();
                foreach (var i_Id in ListIdMember)
                {
                    var userName = _context.App_Users.FirstOrDefault(u => u.Id.Equals(i_Id)
                                                                    && u.IsDeleted.Equals(EnumStatus.False)
                                                                    ).UserName;
                    listUserName.Add(userName);
                }
                return listUserName;
            }
            catch (Exception e)
            {
                throw new MarvicException($"Error: {e}");
            }
        }

        public List<string> Get_List_UserName_Can_Added_By_IdProject(Guid IdProject)
        {
            try
            {
                // All Id members
                var listIdAllMembers = Get_All_IdMembers();
                // Id Member in Project
                var listIdMembers = Get_IdMembers_By_IdProject(IdProject);
                // not contain in Project
                var listMembersCanAdded = listIdAllMembers.Except(listIdMembers).ToList();
                var listUserNames = Get_UserNames_By_Ids(listMembersCanAdded);

                return listUserNames;
            }
            catch (Exception e)
            {
                throw new MarvicException($"Error: {e}");
            }
        }

        public Guid Remove_Member_From_Project(Guid IdProject, Guid IdUser)
        {
            try
            {
                var member = _context.Members.FirstOrDefault(m => m.Id_Project.Equals(IdProject)
                                                            && m.Id_User.Equals(IdUser)
                                                            && m.IsDeleted.Equals(EnumStatus.False)
                                                            );
                member.IsDeleted = EnumStatus.True;
                _context.SaveChanges();

                return member.Id_Project;
            }
            catch (Exception e)
            {
                throw new MarvicException($"Error: {e}");
            }
        }



    }
}
