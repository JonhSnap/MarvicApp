using MarvicSolution.DATA.Common;
using MarvicSolution.DATA.EF;
using MarvicSolution.DATA.Entities;
using MarvicSolution.DATA.Enums;
using MarvicSolution.Services.Project_Request.Project_Resquest.Dtos;
using MarvicSolution.Services.Project_Request.Project_Resquest.Dtos.ViewModels;
using MarvicSolution.Services.SendMail_Request.Dtos.Requests;
using MarvicSolution.Services.SendMail_Request.Dtos.Services;
using MarvicSolution.Services.System.Users.Services;
using MarvicSolution.Utilities.Exceptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvicSolution.Services.Project_Request.Project_Resquest
{
    public class Project_Service : IProject_Service
    {
        #region Test
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
        #endregion
        private readonly MarvicDbContext _context;
        private readonly IUser_Service _userService;
        private readonly IMailService _mailService;

        public Project_Service(MarvicDbContext context
            , IUser_Service userService
            , IMailService mailService)
        {
            _context = context;
            _userService = userService;
            _mailService = mailService;
        }
        public async Task<Guid> Create(Project_CreateRequest rq)
        {
            using (IDbContextTransaction tran = _context.Database.BeginTransaction())
            {
                try
                {
                    // Create a new Project
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

                    // Add Members
                    AddMembers(proj.Id, proj.Id_Lead, proj.Id_Creator);

                    // Get Users
                    var lead = _userService.GetUserbyId(proj.Id_Lead);
                    var creator = _userService.GetUserbyId(proj.Id_Creator);
                    // Add Many Member Params To List
                    List<App_User> listUser = new List<App_User>();
                    listUser.Add(lead);
                    listUser.Add(creator);
                    // Remove null item 
                    listUser.RemoveAll(i => i == null);
                    // Remove Duplicate user
                    var listRemoveDuplicate = listUser.Distinct().ToList();
                    // Create New Instants For Member
                    string message = $"Welcome to {proj.Name} Project. " +
                        $"You are an member of it." +
                        $" Link: <a href=\"http://localhost:3000/projects/board/{proj.Key} \">Click here</a>";
                    List<ProjectMailRequest> list_PMRequest = _mailService.ConvertTo_PMRequest(listRemoveDuplicate);
                    // Send Email
                    _mailService.SendEmail(proj, list_PMRequest, message);
                    tran.Commit();

                    return proj.Id;
                }
                catch (Exception e)
                {
                    tran.Rollback();
                    throw new MarvicException($"Error: {e}");
                }
            }
        }
        public Project_ViewModel GetProjectById(Guid Id)
        {
            try
            {
                var proj = (from p in _context.Projects
                            join u in _context.App_Users on p.Id_Lead equals u.Id
                            where p.Id.Equals(Id)
                            select new Project_ViewModel()
                            {
                                Id = p.Id,
                                Name = p.Name,
                                Key = p.Key,
                                Access = p.Access,
                                Lead = u.UserName,
                                Id_Creator = p.Id_Creator,
                                DateCreated = p.DateCreated,
                                DateEnd = p.DateEnd,
                                Id_Updator = p.Id_Updator,
                                UpdateDate = p.UpdateDate,
                                IsStared = p.IsStared
                            }).FirstOrDefault();

                if (proj == null)
                    throw new MarvicException($"Cannot find the project with id: {Id}");

                return proj;
            }
            catch (Exception e)
            {
                throw new MarvicException($"Error: {e}");
            }
        }
        public async Task<Guid> Update(Project_UpdateRequest rq)
        {
            using (IDbContextTransaction tran = _context.Database.BeginTransaction())
            {
                try
                {
                    var proj = _context.Projects.Where(x => x.IsDeleted.Equals(EnumStatus.False))
                                                .SingleOrDefault(x => x.Id.Equals(rq.Id));
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
                    tran.Commit();

                    // get all id members
                    List<App_User> listUser = GetAllMembersByIdProject(proj.Id);
                    // get members entities
                    List<ProjectMailRequest> list_PMRequest = _mailService.ConvertTo_PMRequest(listUser);

                    // sent mail
                    string message = $"Project {proj.Name} has been updated. Link: <a href=\"http://localhost:3000/projects/board/{proj.Key} \">Click here</a>";
                    _mailService.SendEmail(proj, list_PMRequest, message);

                    return rq.Id;
                }
                catch (Exception e)
                {
                    tran.Rollback();
                    throw new MarvicException($"Error: {e}");
                }
            }
        }
        public async Task<Guid> Delete(Guid Id)
        {
            using (IDbContextTransaction tran = _context.Database.BeginTransaction())
            {
                try
                {
                    var proj = _context.Projects.Where(x => x.IsDeleted.Equals(EnumStatus.False))
                                                .SingleOrDefault(x => x.Id.Equals(Id));
                    proj.IsDeleted = EnumStatus.True;
                    await _context.SaveChangesAsync();
                    List<App_User> listMember = GetAllMembersByIdProject(Id);
                    Remove_Many_Member_From_Project(Id);
                    tran.Commit();
                    // get members entities
                    List<ProjectMailRequest> list_PMRequest = _mailService.ConvertTo_PMRequest(listMember);
                    // sent mail
                    string message = $"Project {proj.Name} has been deleted.";
                    _mailService.SendEmail(proj, list_PMRequest, message);
                    return Id;
                }
                catch (Exception e)
                {
                    tran.Rollback();
                    throw new MarvicException($"Error: {e}");
                }
            }
        }
        public List<Project_ViewModel> GetProjectByIdUser(Guid IdUser)
        {
            try
            {
                var projects = (from u in _context.App_Users
                                join mem in _context.Members on u.Id equals mem.Id_User
                                join p in _context.Projects on mem.Id_Project equals p.Id
                                where p.IsDeleted.Equals(EnumStatus.False) && u.Id.Equals(IdUser)
                                select new Project_ViewModel
                                {
                                    Id = p.Id,
                                    Name = p.Name,
                                    Key = p.Key,
                                    Access = p.Access,
                                    Lead = u.UserName,
                                    Id_Creator = p.Id_Creator,
                                    DateCreated = p.DateCreated,
                                    DateEnd = p.DateEnd,
                                    Id_Updator = p.Id_Updator,
                                    UpdateDate = p.UpdateDate,
                                    IsStared = p.IsStared
                                }).ToList();
                return projects;
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
            using (IDbContextTransaction tran = _context.Database.BeginTransaction())
            {
                try
                {
                    foreach (var i_name in userNames)
                    {
                        Member member = new Member { Id_Project = IdProject, Id_User = GetIdUserByUserName(i_name) };
                        _context.Members.Add(member);
                    }

                    _context.SaveChanges();
                    tran.Commit();
                    return IdProject;
                }
                catch (Exception e)
                {
                    tran.Rollback();
                    throw new MarvicException($"Error: {e}");
                }
            }
        }
        public Guid AddMembers(Guid IdProject, params Guid[] idUser)
        {
            try
            {
                var listRemoveDuplicate = idUser.Distinct();
                foreach (var i_Id in listRemoveDuplicate)
                {
                    Member member = new Member { Id_Project = IdProject, Id_User = i_Id };
                    _context.Members.Add(member);
                }
                _context.SaveChanges();
                return IdProject;
            }
            catch (Exception e) { throw new MarvicException($"Error: {e}"); }
        }
        public List<Guid> Get_IdMembers_By_IdProject(Guid IdProject)
        {
            return _context.Members.Where(m => m.Id_Project.Equals(IdProject)
                                        ).Select(m => m.Id_User).ToList();
        }
        public List<Guid> Get_All_IdMembers()
        {
            try
            {
                return _context.Members.Select(m => m.Id_User).ToList();
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
                                                            );
                _context.Remove(member);
                _context.SaveChanges();
                return member.Id_Project;
            }
            catch (Exception e)
            {
                throw new MarvicException($"Error: {e}");
            }
        }
        public bool Remove_Many_Member_From_Project(Guid IdProject)
        {
            try
            {
                var member = (_context.Members.Where(m => m.Id_Project.Equals(IdProject))
                                                .Select(x => x)).ToList();
                _context.Members.RemoveRange(member);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                throw new MarvicException($"Error: {e}");
            }
        }
        public List<Member_ViewModel> Get_AllMembers_By_IdProject(Guid IdProject)
        {
            try
            {
                return (from mem in _context.Members
                        join u in _context.App_Users on mem.Id_User equals u.Id
                        where mem.Id_Project.Equals(IdProject) && u.IsDeleted.Equals(EnumStatus.False)
                        select new Member_ViewModel()
                        {
                            Id = u.Id,
                            FullName = u.FullName,
                            UserName = u.UserName,
                            Email = u.Email,
                            JobTitle = u.JobTitle,
                            Department = u.Department,
                            Organization = u.Organization,
                            PhoneNumber = u.PhoneNumber
                        }).ToList();
            }
            catch (Exception e)
            {
                throw new MarvicException($"Error: {e}");
            }
        }
        public List<App_User> GetAllMembersByIdProject(Guid idProject)
        {
            var user = from mem in _context.Members
                       join u in _context.App_Users on mem.Id_User equals u.Id
                       where mem.Id_Project.Equals(idProject) && u.IsDeleted.Equals(EnumStatus.False)
                       select new App_User()
                       {
                           Id = u.Id,
                           FullName = u.FullName,
                           UserName = u.UserName,
                           Password = u.Password,
                           Email = u.Email,
                           JobTitle = u.JobTitle,
                           Department = u.Department,
                           Organization = u.Organization,
                           PhoneNumber = u.PhoneNumber
                       };
            return user.ToList();
        }
        // GetAlls Linq
        public async Task<List<Project_ViewModel>> GetAlls()
        {
            try
            {
                var data = await (from proj in _context.Projects
                                  join u in _context.App_Users on proj.Id_Lead equals u.Id
                                  where proj.IsDeleted.Equals(EnumStatus.False)
                                  select new Project_ViewModel()
                                  {
                                      Id = proj.Id,
                                      Name = proj.Name,
                                      Key = proj.Key,
                                      Access = proj.Access,
                                      Lead = u.UserName,
                                      Id_Creator = proj.Id_Creator,
                                      DateCreated = proj.DateCreated,
                                      DateEnd = proj.DateEnd,
                                      Id_Updator = proj.Id_Updator,
                                      UpdateDate = proj.UpdateDate,
                                      IsStared = proj.IsStared
                                  }).ToListAsync();

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
    }
}
