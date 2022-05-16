using MarvicSolution.DATA.Common;
using MarvicSolution.DATA.EF;
using MarvicSolution.DATA.Entities;
using MarvicSolution.DATA.Enums;
using MarvicSolution.Services.Issue_Request.Dtos.Requests;
using MarvicSolution.Services.Issue_Request.Dtos.ViewModels;
using MarvicSolution.Services.Issue_Request.Dtos.ViewModels.Board;
using MarvicSolution.Services.Issue_Request.Issue_Request.Dtos;
using MarvicSolution.Services.Issue_Request.Issue_Request.Dtos.ViewModels;
using MarvicSolution.Services.Project_Request.Project_Resquest;
using MarvicSolution.Services.System.Users.Services;
using MarvicSolution.Utilities.Exceptions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvicSolution.Services.Issue_Request.Issue_Request
{
    public class Issue_Service : IIssue_Service
    {
        private readonly MarvicDbContext _context;
        private readonly IUser_Service _userService;
        private readonly IProject_Service _projectService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public Issue_Service(MarvicDbContext context
            , IUser_Service userService
            , IProject_Service projectService
            , IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _userService = userService;
            _projectService = projectService;
            _webHostEnvironment = webHostEnvironment;
        }
        public async Task<Guid> Create(Issue_CreateRequest rq)
        {
            using (IDbContextTransaction tran = _context.Database.BeginTransaction())
            {
                try
                {
                    var issue = new Issue()
                    {
                        Id_Project = rq.Id_Project,
                        Id_IssueType = rq.Id_IssueType,
                        Id_Stage = rq.Id_Stage,
                        Id_Sprint = rq.Id_Sprint,
                        Id_Label = rq.Id_Label,
                        Summary = rq.Summary,
                        Description = rq.Description,
                        Id_Assignee = rq.Id_Assignee,
                        Story_Point_Estimate = rq.Story_Point_Estimate,
                        Id_Reporter = rq.Id_Reporter.Equals(Guid.Empty) ? UserLogin.Id : rq.Id_Reporter,
                        FileName = string.Empty,
                        Id_Linked_Issue = rq.Id_Linked_Issue,
                        Id_Parent_Issue = rq.Id_Parent_Issue,
                        Priority = rq.Priority,
                        Id_Restrict = rq.Id_Restrict,
                        IsFlagged = rq.IsFlagged,
                        IsWatched = rq.IsWatched,
                        Id_Creator = UserLogin.Id,
                        DateCreated = DateTime.Now,
                        DateStarted = rq.DateStarted,
                        Order = rq.Order,
                        DateEnd = rq.DateEnd
                    };

                    _context.Issues.Add(issue);
                    await _context.SaveChangesAsync();
                    tran.Commit();
                    return issue.Id;
                }
                catch (Exception e)
                {
                    tran.Rollback();
                    throw new MarvicException($"Error: {e}");
                }
            }

        }
        public async Task<Guid> Update(Issue_UpdateRequest rq)
        {
            using (IDbContextTransaction tran = _context.Database.BeginTransaction())
            {
                try
                {
                    var issue = _context.Issues.Find(rq.Id);
                    if (issue == null)
                        throw new MarvicException($"Cannot find the issue with id: {rq.Id}");
                    issue.Id_Project = rq.Id_Project;
                    issue.Id_IssueType = rq.Id_IssueType;
                    issue.Id_Stage = rq.Id_Stage;
                    issue.Id_Sprint = rq.Id_Sprint;
                    issue.Id_Label = rq.Id_Label;
                    issue.Summary = rq.Summary;
                    issue.Description = rq.Description;
                    issue.Id_Assignee = rq.Id_Assignee;
                    issue.Story_Point_Estimate = rq.Story_Point_Estimate;
                    issue.Id_Reporter = rq.Id_Reporter;
                    issue.Id_Linked_Issue = rq.Id_Linked_Issue;
                    issue.Id_Parent_Issue = rq.Id_Parent_Issue;
                    issue.Priority = rq.Priority;
                    issue.Id_Restrict = rq.Id_Restrict;
                    issue.IsFlagged = rq.IsFlagged;
                    issue.IsWatched = rq.IsWatched;
                    issue.DateStarted = rq.DateStarted;
                    issue.DateEnd = rq.DateEnd;
                    issue.Id_Updator = UserLogin.Id;
                    issue.Order = rq.Order;
                    issue.UpdateDate = DateTime.Now;

                    await _context.SaveChangesAsync();
                    tran.Commit();
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
                    var issue = _context.Issues.Find(Id);
                    issue.IsDeleted = EnumStatus.True;
                    await _context.SaveChangesAsync();
                    await tran.CommitAsync();
                    return Id;
                }
                catch (Exception e)
                {
                    tran.Rollback();
                    throw new MarvicException($"Issue id {Id} has error\n Error Delete Issue: {e}");
                }

            }
        }
        public List<Issue_ViewModel> Get_Issues_By_IdProject(Guid idProject, RequestVM rq)
        {
            var issues = (_context.Issues.Where(i => i.Id_Project.Equals(idProject)
                                                    && i.IsDeleted.Equals(EnumStatus.False))
                                        .Select(x => new Issue_ViewModel()
                                        {
                                            Id = x.Id,
                                            Id_Project = x.Id_Project,
                                            Id_Stage = x.Id_Stage,
                                            Id_Sprint = x.Id_Sprint,
                                            Id_IssueType = x.Id_IssueType,
                                            Summary = x.Summary,
                                            Description = x.Description,
                                            Id_Assignee = x.Id_Assignee,
                                            Story_Point_Estimate = x.Story_Point_Estimate,
                                            Id_Reporter = x.Id_Reporter,
                                            FileName = x.FileName,
                                            Attachment_Path = x.FileName.Equals(string.Empty) ? string.Empty : string.Format("{0}://{1}{2}/upload files/{3}", rq.Shceme, rq.Host, rq.PathBase, x.FileName),
                                            Id_Linked_Issue = x.Id_Linked_Issue,
                                            Id_Parent_Issue = x.Id_Parent_Issue,
                                            Priority = x.Priority,
                                            Id_Restrict = x.Id_Restrict,
                                            IsFlagged = x.IsFlagged,
                                            IsWatched = x.IsWatched,
                                            Id_Creator = x.Id_Creator,
                                            DateCreated = x.DateCreated,
                                            DateStarted = x.DateStarted,
                                            DateEnd = x.DateEnd,
                                            Order = x.Order,
                                            Id_Updator = x.Id_Updator
                                        })).ToList();
            return issues;
        }
        public List<GroupByAssignee_ViewModel> Group_By_Assignee(Guid IdProject, RequestVM rq)
        {
            try
            {
                // group IdAssignee
                var groupIdAssignee = from i in _context.Issues.ToList()
                                      where i.Id_Project.Equals(IdProject) && i.IsDeleted.Equals(EnumStatus.False)
                                      orderby i.Id_Assignee
                                      group i by i.Id_Assignee;
                // create new instance listGroupVM to return
                List<GroupByAssignee_ViewModel> listGroupVM = new List<GroupByAssignee_ViewModel>();
                foreach (var i_group in groupIdAssignee)
                {
                    GroupByAssignee_ViewModel groupVM = new GroupByAssignee_ViewModel();
                    var assignee = _userService.GetUserbyId((Guid)i_group.Key);
                    if (assignee == null)
                        groupVM.AssigneeName = "Unassigned";
                    else
                        groupVM.AssigneeName = _userService.GetUserbyId((Guid)i_group.Key).UserName;


                    var item = i_group.Select(g => new Issue_ViewModel()
                    {
                        Id = g.Id,
                        Id_Project = g.Id_Project,
                        Id_IssueType = g.Id_IssueType,
                        Id_Stage = g.Id_Stage,
                        Id_Sprint = g.Id_Sprint,
                        Id_Label = g.Id_Label,
                        Summary = g.Summary,
                        Description = g.Description,
                        Id_Assignee = g.Id_Assignee,
                        Story_Point_Estimate = g.Story_Point_Estimate,
                        Id_Reporter = g.Id_Reporter,
                        FileName = g.FileName,
                        Attachment_Path = g.FileName.Equals(string.Empty) ? string.Empty : string.Format("{0}://{1}{2}/upload files/{3}", rq.Shceme, rq.Host, rq.PathBase, g.FileName),
                        Id_Linked_Issue = g.Id_Linked_Issue,
                        Id_Parent_Issue = g.Id_Parent_Issue,
                        Priority = g.Priority,
                        Id_Restrict = g.Id_Restrict,
                        IsFlagged = g.IsFlagged,
                        IsWatched = g.IsWatched,
                        Id_Creator = g.Id_Creator,
                        DateCreated = g.DateCreated,
                        DateStarted = g.DateStarted,
                        DateEnd = g.DateEnd,
                        Id_Updator = g.Id_Updator,
                        UpdateDate = g.UpdateDate,
                        Order = g.Order
                    });
                    groupVM.ListIssue.AddRange(item);
                    listGroupVM.Add(groupVM);
                }

                return listGroupVM;
            }
            catch (Exception e)
            {
                throw new MarvicException($"Error: {e}");
            }
        }
        public List<GroupByIssueType_ViewModel> Group_By_IssueType(Guid IdProject, RequestVM rq)
        {
            try
            {
                var groupIssueType = from i in _context.Issues.ToList()
                                     where i.Id_Project.Equals(IdProject) && i.IsDeleted.Equals(EnumStatus.False)
                                     orderby i.Id_IssueType
                                     group i by i.Id_IssueType;
                List<GroupByIssueType_ViewModel> listGroupVM = new List<GroupByIssueType_ViewModel>();
                foreach (var i_group in groupIssueType)
                {
                    GroupByIssueType_ViewModel groupVM = new GroupByIssueType_ViewModel();
                    switch (i_group.Key)
                    {
                        case EnumIssueType.Epic:
                            groupVM.TypeName = "Epic";
                            break;
                        case EnumIssueType.Story:
                            groupVM.TypeName = "Story";
                            break;
                        case EnumIssueType.Task:
                            groupVM.TypeName = "Task";
                            break;
                        case EnumIssueType.Bug:
                            groupVM.TypeName = "Bug";
                            break;
                        default:
                            break;
                    }
                    var item = i_group.Select(g => new Issue_ViewModel()
                    {
                        Id = g.Id,
                        Id_Project = g.Id_Project,
                        Id_IssueType = g.Id_IssueType,
                        Id_Stage = g.Id_Stage,
                        Id_Sprint = g.Id_Sprint,
                        Id_Label = g.Id_Label,
                        Summary = g.Summary,
                        Description = g.Description,
                        Id_Assignee = g.Id_Assignee,
                        Story_Point_Estimate = g.Story_Point_Estimate,
                        Id_Reporter = g.Id_Reporter,
                        FileName = g.FileName,
                        Attachment_Path = g.FileName.Equals(string.Empty) ? string.Empty : string.Format("{0}://{1}{2}/upload files/{3}", rq.Shceme, rq.Host, rq.PathBase, g.FileName),
                        Id_Linked_Issue = g.Id_Linked_Issue,
                        Id_Parent_Issue = g.Id_Parent_Issue,
                        Priority = g.Priority,
                        Id_Restrict = g.Id_Restrict,
                        IsFlagged = g.IsFlagged,
                        IsWatched = g.IsWatched,
                        Id_Creator = g.Id_Creator,
                        DateCreated = g.DateCreated,
                        DateStarted = g.DateStarted,
                        DateEnd = g.DateEnd,
                        Id_Updator = g.Id_Updator,
                        UpdateDate = g.UpdateDate,
                        Order = g.Order
                    });
                    groupVM.ListIssue.AddRange(item);
                    listGroupVM.Add(groupVM);
                }

                return listGroupVM;
            }
            catch (Exception e)
            {
                throw new MarvicException($"Error: {e}");
            }
        }
        public List<GroupByPriority_ViewModel> Group_By_Priority(Guid IdProject, RequestVM rq)
        {
            try
            {
                var groupPriority = from i in _context.Issues.ToList()
                                    where i.Id_Project.Equals(IdProject)
                                        && i.IsDeleted.Equals(EnumStatus.False)
                                    orderby i.Priority descending
                                    group i by i.Priority;
                List<GroupByPriority_ViewModel> listGroupVM = new List<GroupByPriority_ViewModel>();
                foreach (var i_group in groupPriority)
                {
                    GroupByPriority_ViewModel groupVM = new GroupByPriority_ViewModel();

                    switch (i_group.Key)
                    {
                        case EnumPriority.Highest:
                            groupVM.Priority = "Highest";
                            break;
                        case EnumPriority.High:
                            groupVM.Priority = "High";
                            break;
                        case EnumPriority.Medium:
                            groupVM.Priority = "Medium";
                            break;
                        case EnumPriority.Low:
                            groupVM.Priority = "Low";
                            break;
                        case EnumPriority.Lowest:
                            groupVM.Priority = "Lowest";
                            break;
                        default:
                            break;
                    }
                    var item = i_group.Select(g => new Issue_ViewModel()
                    {
                        Id = g.Id,
                        Id_Project = g.Id_Project,
                        Id_IssueType = g.Id_IssueType,
                        Id_Stage = g.Id_Stage,
                        Id_Sprint = g.Id_Sprint,
                        Id_Label = g.Id_Label,
                        Summary = g.Summary,
                        Description = g.Description,
                        Id_Assignee = g.Id_Assignee,
                        Story_Point_Estimate = g.Story_Point_Estimate,
                        Id_Reporter = g.Id_Reporter,
                        FileName = g.FileName,
                        Attachment_Path = g.FileName.Equals(string.Empty) ? string.Empty : string.Format("{0}://{1}{2}/upload files/{3}", rq.Shceme, rq.Host, rq.PathBase, g.FileName),
                        Id_Linked_Issue = g.Id_Linked_Issue,
                        Id_Parent_Issue = g.Id_Parent_Issue,
                        Priority = g.Priority,
                        Id_Restrict = g.Id_Restrict,
                        IsFlagged = g.IsFlagged,
                        IsWatched = g.IsWatched,
                        Id_Creator = g.Id_Creator,
                        DateCreated = g.DateCreated,
                        DateStarted = g.DateStarted,
                        DateEnd = g.DateEnd,
                        Id_Updator = g.Id_Updator,
                        UpdateDate = g.UpdateDate,
                        Order = g.Order
                    });
                    groupVM.ListIssue.AddRange(item);
                    listGroupVM.Add(groupVM);
                }

                return listGroupVM;
            }
            catch (Exception e)
            {
                throw new MarvicException($"Error: {e}");
            }
        }
        public List<Issue_ViewModel> Get_Issue_By_IdParent(Guid IdProject, Guid IdParent, RequestVM rq)
        {
            var issues = (_context.Issues.Where(i => i.Id_Project.Equals(IdProject)
                                                    && i.Id_Parent_Issue.Equals(IdParent)
                                                    && i.IsDeleted.Equals(EnumStatus.False))
                                        .Select(x => new Issue_ViewModel()
                                        {
                                            Id = x.Id,
                                            Id_Project = x.Id_Project,
                                            Id_Stage = x.Id_Stage,
                                            Id_Sprint = x.Id_Sprint,
                                            Id_IssueType = x.Id_IssueType,
                                            Summary = x.Summary,
                                            Description = x.Description,
                                            Id_Assignee = x.Id_Assignee,
                                            Story_Point_Estimate = x.Story_Point_Estimate,
                                            Id_Reporter = x.Id_Reporter,
                                            FileName = x.FileName,
                                            Attachment_Path = x.FileName.Equals(string.Empty) ? string.Empty : string.Format("{0}://{1}{2}/upload files/{3}", rq.Shceme, rq.Host, rq.PathBase, x.FileName),
                                            Id_Linked_Issue = x.Id_Linked_Issue,
                                            Id_Parent_Issue = x.Id_Parent_Issue,
                                            Priority = x.Priority,
                                            Id_Restrict = x.Id_Restrict,
                                            IsFlagged = x.IsFlagged,
                                            IsWatched = x.IsWatched,
                                            Id_Creator = x.Id_Creator,
                                            DateCreated = x.DateCreated,
                                            DateStarted = x.DateStarted,
                                            DateEnd = x.DateEnd,
                                            Order = x.Order,
                                            Id_Updator = x.Id_Updator
                                        })).ToList();

            return issues;
        }
        public List<Issue_ViewModel> Get_Issues_By_IdUser(Guid idProject, Guid idUser, RequestVM rq)
        {
            var issues = (_context.Issues.Where(i => i.Id_Project.Equals(idProject)
                                                    && (i.Id_Assignee.Equals(idUser) || i.Id_Reporter.Equals(idUser))
                                                    && i.IsDeleted.Equals(EnumStatus.False))
                                        .Select(x => new Issue_ViewModel()
                                        {
                                            Id = x.Id,
                                            Id_Project = x.Id_Project,
                                            Id_Stage = x.Id_Stage,
                                            Id_Sprint = x.Id_Sprint,
                                            Id_IssueType = x.Id_IssueType,
                                            Summary = x.Summary,
                                            Description = x.Description,
                                            Id_Assignee = x.Id_Assignee,
                                            Story_Point_Estimate = x.Story_Point_Estimate,
                                            Id_Reporter = x.Id_Reporter,
                                            FileName = x.FileName,
                                            Attachment_Path = x.FileName.Equals(string.Empty) ? string.Empty : string.Format("{0}://{1}{2}/upload files/{3}", rq.Shceme, rq.Host, rq.PathBase, x.FileName),
                                            Id_Linked_Issue = x.Id_Linked_Issue,
                                            Id_Parent_Issue = x.Id_Parent_Issue,
                                            Priority = x.Priority,
                                            Id_Restrict = x.Id_Restrict,
                                            IsFlagged = x.IsFlagged,
                                            IsWatched = x.IsWatched,
                                            Id_Creator = x.Id_Creator,
                                            DateCreated = x.DateCreated,
                                            DateStarted = x.DateStarted,
                                            DateEnd = x.DateEnd,
                                            Id_Updator = x.Id_Updator,
                                            Order = x.Order
                                        })).ToList();

            return issues;
        }
        public List<Issue_ViewModel> Get_Issue_By_IdLabel(Guid IdProject, Guid IdLabel, RequestVM rq)
        {
            try
            {
                var issues = (_context.Issues.Where(i => i.Id_Project.Equals(IdProject)
                                                        && i.Id_Label.Equals(IdLabel))
                                        .Select(x => new Issue_ViewModel()
                                        {
                                            Id = x.Id,
                                            Id_Project = x.Id_Project,
                                            Id_Stage = x.Id_Stage,
                                            Id_Sprint = x.Id_Sprint,
                                            Id_IssueType = x.Id_IssueType,
                                            Summary = x.Summary,
                                            Description = x.Description,
                                            Id_Assignee = x.Id_Assignee,
                                            Story_Point_Estimate = x.Story_Point_Estimate,
                                            Id_Reporter = x.Id_Reporter,
                                            FileName = x.FileName,
                                            Attachment_Path = x.FileName.Equals(string.Empty) ? string.Empty : string.Format("{0}://{1}{2}/upload files/{3}", rq.Shceme, rq.Host, rq.PathBase, x.FileName),
                                            Id_Linked_Issue = x.Id_Linked_Issue,
                                            Id_Parent_Issue = x.Id_Parent_Issue,
                                            Priority = x.Priority,
                                            Id_Restrict = x.Id_Restrict,
                                            IsFlagged = x.IsFlagged,
                                            IsWatched = x.IsWatched,
                                            Id_Creator = x.Id_Creator,
                                            DateCreated = x.DateCreated,
                                            DateStarted = x.DateStarted,
                                            DateEnd = x.DateEnd,
                                            Id_Updator = x.Id_Updator,
                                            Order = x.Order
                                        })).ToList();
                return issues;
            }
            catch (Exception e)
            {
                throw new MarvicException($"Error: {e}");
            }
        }
        public List<GroupByProject_ViewModel> Group_By_IdUser(Guid IdUser, RequestVM rq)
        {
            // Group issue by Project use Id user login
            var groupProject = from mem in _context.Members.ToList()
                               join u in _context.App_Users.ToList() on mem.Id_User equals u.Id
                               join p in _context.Projects.ToList() on mem.Id_Project equals p.Id
                               join i in _context.Issues.ToList() on p.Id equals i.Id_Project
                               where u.IsDeleted.Equals(EnumStatus.False)
                                    && i.IsDeleted.Equals(EnumStatus.False)
                                    && p.IsDeleted.Equals(EnumStatus.False)
                                    && u.Id.Equals(IdUser)
                                    && (IdUser.Equals(i.Id_Assignee) || IdUser.Equals(i.Id_Reporter))
                               orderby p.Name
                               group i by p.Id;
            List<GroupByProject_ViewModel> listGroupVM = new List<GroupByProject_ViewModel>();
            foreach (var i_group in groupProject)
            {
                GroupByProject_ViewModel groupVM = new GroupByProject_ViewModel();
                groupVM.ProjectName = _projectService.GetProjectById(i_group.Key).Name;
                var item = i_group.Select(g => new Issue_ViewModel()
                {
                    Id = g.Id,
                    Id_Project = g.Id_Project,
                    Id_IssueType = g.Id_IssueType,
                    Id_Stage = g.Id_Stage,
                    Id_Sprint = g.Id_Sprint,
                    Id_Label = g.Id_Label,
                    Summary = g.Summary,
                    Description = g.Description,
                    Id_Assignee = g.Id_Assignee,
                    Story_Point_Estimate = g.Story_Point_Estimate,
                    Id_Reporter = g.Id_Reporter,
                    FileName = g.FileName,
                    Attachment_Path = g.FileName.Equals(string.Empty) ? string.Empty : string.Format("{0}://{1}{2}/upload files/{3}", rq.Shceme, rq.Host, rq.PathBase, g.FileName),
                    Id_Linked_Issue = g.Id_Linked_Issue,
                    Id_Parent_Issue = g.Id_Parent_Issue,
                    Priority = g.Priority,
                    Id_Restrict = g.Id_Restrict,
                    IsFlagged = g.IsFlagged,
                    IsWatched = g.IsWatched,
                    Id_Creator = g.Id_Creator,
                    DateCreated = g.DateCreated,
                    DateStarted = g.DateStarted,
                    DateEnd = g.DateEnd,
                    Id_Updator = g.Id_Updator,
                    UpdateDate = g.UpdateDate,
                    Order = g.Order
                });
                groupVM.ListIssue.AddRange(item);
                listGroupVM.Add(groupVM);
            }
            return listGroupVM;
        }
        public List<Issue_ViewModel> Get_Issues_By_IdSprint(Guid idSprint, RequestVM rq)
        {
            try
            {
                var issues = _context.Issues.Where(i => i.Id_Sprint.Equals(idSprint)
                                                        && i.IsDeleted.Equals(EnumStatus.False))
                                            .Select(i => new Issue_ViewModel()
                                            {
                                                Id = i.Id,
                                                Id_Project = i.Id_Project,
                                                Id_Stage = i.Id_Stage,
                                                Id_Sprint = i.Id_Sprint,
                                                Id_IssueType = i.Id_IssueType,
                                                Summary = i.Summary,
                                                Description = i.Description,
                                                Id_Assignee = i.Id_Assignee,
                                                Story_Point_Estimate = i.Story_Point_Estimate,
                                                Id_Reporter = i.Id_Reporter,
                                                FileName = i.FileName,
                                                Attachment_Path = i.FileName.Equals(string.Empty) ? string.Empty : string.Format("{0}://{1}{2}/upload files/{3}", rq.Shceme, rq.Host, rq.PathBase, i.FileName),
                                                Id_Linked_Issue = i.Id_Linked_Issue,
                                                Id_Parent_Issue = i.Id_Parent_Issue,
                                                Priority = i.Priority,
                                                Id_Restrict = i.Id_Restrict,
                                                IsFlagged = i.IsFlagged,
                                                IsWatched = i.IsWatched,
                                                Id_Creator = i.Id_Creator,
                                                DateCreated = i.DateCreated,
                                                DateStarted = i.DateStarted,
                                                DateEnd = i.DateEnd,
                                                Id_Updator = i.Id_Updator,
                                                Order = i.Order
                                            });
                return issues.ToList();
            }
            catch (Exception e) { throw new MarvicException($"Error: {e}"); }
        }
        public List<Issue_ViewModel> Get_Issues_NotInSprint_By_IdProject(Guid idProject, RequestVM rq)
        {
            // get issues have idSprint = 000 of Project idProject
            var issues = _context.Issues.Where(i => i.Id_Project.Equals(idProject)
                                                    && i.IsDeleted.Equals(EnumStatus.False)
                                                    && i.Id_Sprint.Equals(Guid.Empty))
                                        .Select(i => new Issue_ViewModel()
                                        {
                                            Id = i.Id,
                                            Id_Project = i.Id_Project,
                                            Id_Stage = i.Id_Stage,
                                            Id_Sprint = i.Id_Sprint,
                                            Id_IssueType = i.Id_IssueType,
                                            Summary = i.Summary,
                                            Description = i.Description,
                                            Id_Assignee = i.Id_Assignee,
                                            Story_Point_Estimate = i.Story_Point_Estimate,
                                            Id_Reporter = i.Id_Reporter,
                                            FileName = i.FileName,
                                            Attachment_Path = i.FileName.Equals(string.Empty) ? string.Empty : string.Format("{0}://{1}{2}/upload files/{3}", rq.Shceme, rq.Host, rq.PathBase, i.FileName),
                                            Id_Linked_Issue = i.Id_Linked_Issue,
                                            Id_Parent_Issue = i.Id_Parent_Issue,
                                            Priority = i.Priority,
                                            Id_Restrict = i.Id_Restrict,
                                            IsFlagged = i.IsFlagged,
                                            IsWatched = i.IsWatched,
                                            Id_Creator = i.Id_Creator,
                                            DateCreated = i.DateCreated,
                                            DateStarted = i.DateStarted,
                                            DateEnd = i.DateEnd,
                                            Id_Updator = i.Id_Updator,
                                            Order = i.Order
                                        });
            return issues.ToList();
        }
        public List<BoardViewModel> GetInforBoardByIdSprint(Guid IdSprint, RequestVM rq)
        {
            // find Sprint
            var sprint = _context.Sprints.Find(IdSprint);
            // get ListStageOrder by idProject
            var listStageOrder = _context.Stages.Where(s => s.Id_Project.Equals(sprint.Id_Project)
                                                            && s.isDeleted.Equals(EnumStatus.False))
                                                .OrderBy(s => s.Order)
                                                .Select(s => s.Id).ToList();
            // group issue by idStage
            var groupIssue = from i in _context.Issues.ToList()
                             join s in _context.Stages.ToList() on i.Id_Stage equals s.Id
                             join spr in _context.Sprints.ToList() on i.Id_Sprint equals spr.Id
                             join pro in _context.Projects.ToList() on i.Id_Project equals pro.Id
                             where i.IsDeleted.Equals(EnumStatus.False)
                             && s.isDeleted.Equals(EnumStatus.False)
                             && spr.Is_Archieved.Equals(EnumStatus.False)
                             && s.Id_Project.Equals(pro.Id)
                             && spr.Id_Project.Equals(s.Id_Project)
                             orderby i.Order
                             group i by i.Id_Stage;
            // prepare variable VM
            var listBoardVM = new List<BoardViewModel>();
            var boardVM = new BoardViewModel();
            var listStageVM = new List<StageViewModel>();

            foreach (var i_group in groupIssue)
            {
                // find stage by key
                var stage = _context.Stages.FirstOrDefault(s => s.Id.Equals(i_group.Key));
                var stageVM = new StageViewModel(stage.Id, stage.Id_Project, stage.Stage_Name, stage.Id_Creator, stage.DateCreated, stage.UpdateDate, stage.Order);

                // add ListIssueOrder
                var listIssueOrder = GetListIssueOrderByIdStage(stage.Id);
                stageVM.ListIssueOrder.AddRange(listIssueOrder);
                var listIssueVM = i_group.Select(g => new Issue_ViewModel()
                {
                    Id = g.Id,
                    Id_Project = g.Id_Project,
                    Id_IssueType = g.Id_IssueType,
                    Id_Stage = g.Id_Stage,
                    Id_Sprint = g.Id_Sprint,
                    Id_Label = g.Id_Label,
                    Summary = g.Summary,
                    Description = g.Description,
                    Id_Assignee = g.Id_Assignee,
                    Story_Point_Estimate = g.Story_Point_Estimate,
                    Id_Reporter = g.Id_Reporter,
                    FileName = g.FileName,
                    Attachment_Path = g.FileName.Equals(string.Empty) ? string.Empty : string.Format("{0}://{1}{2}/upload files/{3}", rq.Shceme, rq.Host, rq.PathBase, g.FileName),
                    Id_Linked_Issue = g.Id_Linked_Issue,
                    Id_Parent_Issue = g.Id_Parent_Issue,
                    Priority = g.Priority,
                    Id_Restrict = g.Id_Restrict,
                    IsFlagged = g.IsFlagged,
                    IsWatched = g.IsWatched,
                    Id_Creator = g.Id_Creator,
                    DateCreated = g.DateCreated,
                    DateStarted = g.DateStarted,
                    DateEnd = g.DateEnd,
                    Id_Updator = g.Id_Updator,
                    UpdateDate = g.UpdateDate,
                    Order = g.Order
                }).ToList();
                // add ListIssue
                stageVM.ListIssue.AddRange(listIssueVM);
                listStageVM.Add(stageVM);
            }


            boardVM.ListStageOrder.AddRange(listStageOrder);
            boardVM.ListStage.AddRange(listStageVM);
            listBoardVM.Add(boardVM);
            return listBoardVM;
        }
        public List<Guid> GetListIssueOrderByIdStage(Guid idStage)
        {
            var issues = _context.Issues.Where(i => i.Id_Stage.Equals(idStage)
                                                && i.IsDeleted.Equals(EnumStatus.False))
                                        .OrderBy(i => i.Order)
                                        .Select(i => i.Id).ToList();
            return issues;
        }
        public List<Guid> GetListIssueOrder(Guid? idStage, Guid? idAssignee)
        {
            var issues = _context.Issues.Where(i => i.Id_Stage.Equals(idStage)
                                                && i.Id_Assignee.Equals(idAssignee)
                                                && i.IsDeleted.Equals(EnumStatus.False))
                                        .OrderBy(i => i.Order)
                                        .Select(i => i.Id).ToList();
            return issues;
        }
        public void UploadedFile(Guid idIssue, IFormFile file)
        {
            var issue = Get_Issues_By_Id(idIssue);
            string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "upload files");
            string uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
            string filePath = Path.Combine(uploadsFolder, uniqueFileName);
            using (var stream = new FileStream(filePath, FileMode.Create))
                file.CopyTo(stream);
            issue.FileName = uniqueFileName;
            _context.SaveChanges();
        }
        public bool DeleteFileIssue(DeleteFile_Request rq)
        {
            var issue = Get_Issues_By_Id(rq.IdIssue);
            issue.FileName = string.Empty;
            return _context.SaveChanges() > 0;
        }
        public Issue Get_Issues_By_Id(Guid idIssue)
        {
            var issue = _context.Issues.FirstOrDefault(i => i.Id.Equals(idIssue)
                                                        && i.IsDeleted.Equals(EnumStatus.False));
            return issue;
        }
        public List<GroupByEpic_ViewModel> Group_By_Epic(Guid IdProject, RequestVM rq)
        {
            var listIdEpic = _context.Issues.Where(i => i.Id_IssueType.Equals(EnumIssueType.Epic)
                                                        && i.Id_Project.Equals(IdProject)
                                                        && i.IsDeleted.Equals(EnumStatus.False))
                                            .Select(i => i.Id).ToList();

            var groupIssueType = from i in _context.Issues.ToList()
                                 where i.Id_Project.Equals(IdProject)
                                 && i.IsDeleted.Equals(EnumStatus.False)
                                 && listIdEpic.Contains((Guid)i.Id_Parent_Issue)
                                 orderby i.Id_IssueType
                                 group i by i.Id_Parent_Issue;

            List<GroupByEpic_ViewModel> listGroupVM = new List<GroupByEpic_ViewModel>();
            foreach (var i_group in groupIssueType)
            {
                GroupByEpic_ViewModel groupVM = new GroupByEpic_ViewModel();
                groupVM.EpicName = _context.Issues.FirstOrDefault(i => i.Id.Equals(i_group.Key)).Summary;
                var item = i_group.Select(g => new Issue_ViewModel()
                {
                    Id = g.Id,
                    Id_Project = g.Id_Project,
                    Id_IssueType = g.Id_IssueType,
                    Id_Stage = g.Id_Stage,
                    Id_Sprint = g.Id_Sprint,
                    Id_Label = g.Id_Label,
                    Summary = g.Summary,
                    Description = g.Description,
                    Id_Assignee = g.Id_Assignee,
                    Story_Point_Estimate = g.Story_Point_Estimate,
                    Id_Reporter = g.Id_Reporter,
                    FileName = g.FileName,
                    Attachment_Path = g.FileName.Equals(string.Empty) ? string.Empty : string.Format("{0}://{1}{2}/upload files/{3}", rq.Shceme, rq.Host, rq.PathBase, g.FileName),
                    Id_Linked_Issue = g.Id_Linked_Issue,
                    Id_Parent_Issue = g.Id_Parent_Issue,
                    Priority = g.Priority,
                    Id_Restrict = g.Id_Restrict,
                    IsFlagged = g.IsFlagged,
                    IsWatched = g.IsWatched,
                    Id_Creator = g.Id_Creator,
                    DateCreated = g.DateCreated,
                    DateStarted = g.DateStarted,
                    DateEnd = g.DateEnd,
                    Id_Updator = g.Id_Updator,
                    UpdateDate = g.UpdateDate,
                    Order = g.Order
                });
                groupVM.ListIssue.AddRange(item);
                listGroupVM.Add(groupVM);
            }
            return listGroupVM;
        }
        public ListGroupByAssignee GroupIssueForBoardByAssignee(Guid IdSprint, RequestVM rq)
        {
            // find Sprint
            var sprint = _context.Sprints.Find(IdSprint);
            // get List Id Assignee in Sprint
            var listIdAssignee = _context.Issues.Where(i => i.Id_Sprint.Equals(sprint.Id)
                                                            && i.IsDeleted.Equals(EnumStatus.False))
                                                    .OrderBy(s => s.Order)
                                                    .Select(s => s.Id_Assignee).Distinct().ToList();
            // make issue not belong to anyone to last
            listIdAssignee.Reverse();

            // get all stage id of Sprint
            var lstStageOfSprint = _context.Stages.Where(s => s.Id_Project.Equals(sprint.Id_Project)
                                                                && s.isDeleted.Equals(EnumStatus.False)
                                                                && sprint.Is_Archieved.Equals(EnumStatus.False))
                                                    .Select(s => s).ToList();
            // sort lstStageOfSprint
            var lstStageOfSprintOrder = lstStageOfSprint.OrderBy(s => s.Order);

            List<Assignee> lstAssignee = new List<Assignee>();
            foreach (var i_id in listIdAssignee)
            {
                var listIssueOfAssignee = _context.Issues.Where(i => i.Id_Assignee.Equals(i_id)
                                                                    && i.IsDeleted.Equals(EnumStatus.False))
                                                         .Select(g => new Issue_ViewModel()
                                                         {
                                                             Id = g.Id,
                                                             Id_Project = g.Id_Project,
                                                             Id_IssueType = g.Id_IssueType,
                                                             Id_Stage = g.Id_Stage,
                                                             Id_Sprint = g.Id_Sprint,
                                                             Id_Label = g.Id_Label,
                                                             Summary = g.Summary,
                                                             Description = g.Description,
                                                             Id_Assignee = g.Id_Assignee,
                                                             Story_Point_Estimate = g.Story_Point_Estimate,
                                                             Id_Reporter = g.Id_Reporter,
                                                             FileName = g.FileName,
                                                             Attachment_Path = g.FileName.Equals(string.Empty) ? string.Empty : string.Format("{0}://{1}{2}/upload files/{3}", rq.Shceme, rq.Host, rq.PathBase, g.FileName),
                                                             Id_Linked_Issue = g.Id_Linked_Issue,
                                                             Id_Parent_Issue = g.Id_Parent_Issue,
                                                             Priority = g.Priority,
                                                             Id_Restrict = g.Id_Restrict,
                                                             IsFlagged = g.IsFlagged,
                                                             IsWatched = g.IsWatched,
                                                             Id_Creator = g.Id_Creator,
                                                             DateCreated = g.DateCreated,
                                                             DateStarted = g.DateStarted,
                                                             DateEnd = g.DateEnd,
                                                             Id_Updator = g.Id_Updator,
                                                             UpdateDate = g.UpdateDate,
                                                             Order = g.Order
                                                         }).ToList();
                // sort listIssueOfAssignee
                var listIssueOfAssigneeOrder = listIssueOfAssignee.OrderBy(i => i.Order).ToList();

                var stageVM = _context.Stages.Where(s => s.Id_Project.Equals(sprint.Id_Project)
                                                                && s.isDeleted.Equals(EnumStatus.False)
                                                                && sprint.Is_Archieved.Equals(EnumStatus.False))
                                             .Select(s => new StageViewModel()
                                             {
                                                 DateCreated = s.DateCreated,
                                                 Id = s.Id,
                                                 Id_Creator = s.Id_Creator,
                                                 Id_Project = s.Id_Project,
                                                 Order = s.Order,
                                                 Stage_Name = s.Stage_Name,
                                                 UpdateDate = s.UpdateDate,
                                                 ListIssue = listIssueOfAssigneeOrder,
                                                 ListIssueOrder = listIssueOfAssigneeOrder.Select(i => i.Id).ToList()
                                             }).ToList();
                // set infor for board
                BoardViewModel boardVM = new BoardViewModel();
                boardVM.ListStageOrder.AddRange(lstStageOfSprintOrder.Select(s => s.Id));
                boardVM.ListStage.AddRange(stageVM);
                // get entity assignee
                var assignee = _context.App_Users.Where(u => u.Id.Equals(i_id)
                                                            && u.IsDeleted.Equals(EnumStatus.False))
                                                 .Select(u => new Assignee()
                                                 {
                                                     Id = u.Id,
                                                     Department = u.Department,
                                                     Email = u.Email,
                                                     FullName = u.FullName,
                                                     JobTitle = u.JobTitle,
                                                     Organization = u.Organization,
                                                     PhoneNumber = u.PhoneNumber,
                                                     UserName = u.UserName,
                                                     Item = boardVM
                                                 }).SingleOrDefault();
                if (assignee != null)
                    lstAssignee.Add(assignee);
                else
                {
                    // issue not belong to anyone
                    Assignee assigneeNull = new Assignee();
                    assigneeNull.Item = boardVM;
                    lstAssignee.Add(assigneeNull);
                }

            }

            ListGroupByAssignee listGroupByAssignee = new ListGroupByAssignee();
            listGroupByAssignee.ListIdAssignee.AddRange(listIdAssignee);
            listGroupByAssignee.ListAssignee.AddRange(lstAssignee);
            return listGroupByAssignee;
        }

    }
}
