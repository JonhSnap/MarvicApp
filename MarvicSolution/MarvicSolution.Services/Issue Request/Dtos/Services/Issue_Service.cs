using MarvicSolution.DATA.Common;
using MarvicSolution.DATA.EF;
using MarvicSolution.DATA.Entities;
using MarvicSolution.DATA.Enums;
using MarvicSolution.Services.Issue_Request.Dtos.Requests;
using MarvicSolution.Services.Issue_Request.Dtos.Requests.Board;
using MarvicSolution.Services.Issue_Request.Dtos.ViewModels;
using MarvicSolution.Services.Issue_Request.Dtos.ViewModels.Archive;
using MarvicSolution.Services.Issue_Request.Dtos.ViewModels.AssignedToMe;
using MarvicSolution.Services.Issue_Request.Dtos.ViewModels.Board;
using MarvicSolution.Services.Issue_Request.Dtos.ViewModels.GroupBy;
using MarvicSolution.Services.Issue_Request.Dtos.ViewModels.WorkedOn;
using MarvicSolution.Services.Issue_Request.Issue_Request.Dtos;
using MarvicSolution.Services.Issue_Request.Issue_Request.Dtos.ViewModels;
using MarvicSolution.Services.Label_Request.Services;
using MarvicSolution.Services.Project_Request.Project_Resquest;
using MarvicSolution.Services.System.Users.Services;
using MarvicSolution.Utilities.Exceptions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger<Issue_Service> _logger;
        private readonly ILabel_Service _label_Service;
        public Issue_Service(MarvicDbContext context
            , IUser_Service userService
            , IProject_Service projectService
            , IWebHostEnvironment webHostEnvironment
            , ILogger<Issue_Service> logger
            , ILabel_Service label_Service)
        {
            _context = context;
            _userService = userService;
            _projectService = projectService;
            _webHostEnvironment = webHostEnvironment;
            _logger = logger;
            _label_Service = label_Service;
        }
        public async Task<Guid> Create(Guid idUser, Issue_CreateRequest rq)
        {
            using (IDbContextTransaction tran = _context.Database.BeginTransaction())
            {
                try
                {
                    // lấy ra default stage và gắn id vào issue
                    var dfStage = _context.Stages.FirstOrDefault(s => s.Id_Project.Equals(rq.Id_Project) && s.isDefault.Equals(EnumStatus.True));

                    var issue = new Issue()
                    {
                        Id_Project = rq.Id_Project,
                        Id_IssueType = rq.Id_IssueType,
                        Id_Stage = dfStage.Id,
                        Id_Sprint = rq.Id_Sprint,
                        Id_Label = rq.Id_Label,
                        Summary = rq.Summary,
                        Description = rq.Description,
                        Id_Assignee = rq.Id_Assignee != null ? rq.Id_Assignee : Guid.Empty,
                        Story_Point_Estimate = rq.Story_Point_Estimate,
                        Id_Reporter = rq.Id_Reporter.Equals(Guid.Empty) ? idUser : rq.Id_Reporter,
                        FileName = string.Empty,
                        Id_Linked_Issue = rq.Id_Linked_Issue,
                        Id_Parent_Issue = rq.Id_Parent_Issue != null ? rq.Id_Parent_Issue : Guid.Empty,
                        Priority = rq.Priority,
                        Id_Restrict = rq.Id_Restrict,
                        IsFlagged = rq.IsFlagged,
                        IsWatched = rq.IsWatched,
                        Id_Creator = idUser,
                        DateCreated = DateTime.Now,
                        Order = rq.Order,
                    };

                    _context.Issues.Add(issue);

                    await _context.SaveChangesAsync();
                    tran.Commit();
                    return issue.Id;
                }
                catch (Exception e)
                {
                    tran.Rollback();
                    _logger.LogInformation($"Controller: Issue. Method: Create. Marvic Error: {e}");
                    throw new MarvicException($"Error: {e}");
                }
            }

        }
        public async Task<Guid> Update(Guid idUser, Issue_UpdateRequest rq)
        {
            using (IDbContextTransaction tran = _context.Database.BeginTransaction())
            {
                try
                {
                    var sprint = _context.Sprints.Find(rq.Id_Sprint);
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
                    issue.DateStarted = sprint != null ? sprint.Start_Date : new DateTime();
                    issue.DateEnd = sprint != null ? sprint.End_Date : new DateTime();
                    issue.Id_Updator = idUser;
                    issue.Order = rq.Order;
                    issue.UpdateDate = DateTime.Now;

                    await _context.SaveChangesAsync();
                    tran.Commit();
                    return rq.Id;
                }
                catch (Exception e)
                {
                    tran.Rollback();
                    _logger.LogInformation($"Controller: Issue. Method: Update. Marvic Error: {e}");
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
                    _logger.LogInformation($"Controller: Issue. Method: Delete. Marvic Error: {e}");
                    throw new MarvicException($"Error: {e}");
                }

            }
        }
        public List<Issue_ViewModel> Get_Issues_By_IdProject(Guid idProject, RequestVM rq)
        {
            try
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
            catch (Exception e)
            {
                _logger.LogInformation($"Controller: Issue. Method: Get_Issues_By_IdProject. Marvic Error: {e}");
                throw new MarvicException($"Error: {e}");
            }

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
                _logger.LogInformation($"Controller: Issue. Method: Group_By_Assignee. Marvic Error: {e}");
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
                _logger.LogInformation($"Controller: Issue. Method: Group_By_IssueType. Marvic Error: {e}");
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
                _logger.LogInformation($"Controller: Issue. Method: Group_By_Priority. Marvic Error: {e}");
                throw new MarvicException($"Error: {e}");
            }
        }
        public List<Issue_ViewModel> Get_Issue_By_IdParent(Guid IdProject, Guid IdParent, RequestVM rq)
        {
            try
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
            catch (Exception e)
            {
                _logger.LogInformation($"Controller: Issue. Method: Get_Issue_By_IdParent. Marvic Error: {e}");
                throw new MarvicException($"Error: {e}");
            }

        }
        public List<Issue_ViewModel> Get_Issues_By_IdUser(Guid idProject, Guid idUser, RequestVM rq)
        {
            try
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
            catch (Exception e)
            {
                _logger.LogInformation($"Controller: Issue. Method: Get_Issues_By_IdUser. Marvic Error: {e}");
                throw new MarvicException($"Error: {e}");
            }

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
                _logger.LogInformation($"Controller: Issue. Method: Get_Issue_By_IdLabel. Marvic Error: {e}");
                throw new MarvicException($"Error: {e}");
            }
        }
        public List<GroupByProject_ViewModel> Group_By_IdUser(Guid IdUser, RequestVM rq)
        {
            try
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
            catch (Exception e)
            {
                _logger.LogInformation($"Controller: Issue. Method: Group_By_IdUser. Marvic Error: {e}");
                throw new MarvicException($"Error: {e}");
            }
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
            catch (Exception e)
            {
                _logger.LogInformation($"Controller: Issue. Method: Get_Issues_By_IdSprint. Marvic Error: {e}");
                throw new MarvicException($"Error: {e}");
            }
        }
        public List<Issue_ViewModel> Get_Issues_NotInSprint_By_IdProject(Guid idProject, RequestVM rq)
        {
            try
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
            catch (Exception e)
            {
                _logger.LogInformation($"Controller: Issue. Method: Get_Issues_NotInSprint_By_IdProject. Marvic Error: {e}");
                throw new MarvicException($"Error: {e}");
            }
        }
        public List<BoardViewModel> GetInforBoardByIdSprint(GetBoardIssue_Request rq, RequestVM rqVM)
        {
            try
            {
                // prepare variable VM
                var listBoardVM = new List<BoardViewModel>();
                var boardVM = new BoardViewModel();
                var listStageVM = new List<StageViewModel>();

                // find Sprint
                var sprint = _context.Sprints.Find(rq.IdSprint);
                // get ListStageOrder by idProject
                var listStageOrder = _context.Stages.Where(s => s.Id_Project.Equals(sprint.Id_Project)
                                                                && s.isDeleted.Equals(EnumStatus.False))
                                                    .OrderBy(s => s.Order)
                                                    .Select(s => new StageViewModel()
                                                    {
                                                        Id = s.Id,
                                                        DateCreated = s.DateCreated,
                                                        Id_Creator = s.Id_Creator,
                                                        Id_Project = s.Id_Project,
                                                        Order = s.Order,
                                                        Stage_Name = s.Stage_Name,
                                                        UpdateDate = s.UpdateDate
                                                    }).ToList();
                // get all issue of stage
                List<Guid> listIdStageOrder = listStageOrder.Select(s => s.Id).ToList();

                foreach (var i_id in listIdStageOrder)
                {
                    // find stage by key
                    var stage = _context.Stages.FirstOrDefault(s => s.Id.Equals(i_id));
                    var stageVM = new StageViewModel(stage.Id, stage.Id_Project, stage.Stage_Name, stage.Id_Creator, stage.DateCreated, stage.UpdateDate, stage.Order);

                    //get list issue by id stage, stage belong to sprint, sprint not archieve, issue is not epic
                    var listIssueVM = (from i in _context.Issues.ToList()
                                       join s in _context.Stages.ToList() on i.Id_Stage equals s.Id
                                       join spr in _context.Sprints.ToList() on i.Id_Sprint equals spr.Id
                                       where i.IsDeleted.Equals(EnumStatus.False)
                                       && !i.Id_IssueType.Equals(EnumIssueType.Epic)
                                       && s.isDeleted.Equals(EnumStatus.False)
                                       && spr.Is_Archieved.Equals(EnumStatus.False)
                                       && spr.Id_Project.Equals(s.Id_Project)
                                       && spr.Id.Equals(rq.IdSprint)
                                       && s.Id.Equals(i_id)
                                       select new Issue_ViewModel()
                                       {
                                           Id = i.Id,
                                           Id_Project = i.Id_Project,
                                           Id_IssueType = i.Id_IssueType,
                                           Id_Stage = i.Id_Stage,
                                           Id_Sprint = i.Id_Sprint,
                                           Id_Label = i.Id_Label,
                                           Summary = i.Summary,
                                           Description = i.Description,
                                           Id_Assignee = i.Id_Assignee,
                                           Story_Point_Estimate = i.Story_Point_Estimate,
                                           Id_Reporter = i.Id_Reporter,
                                           FileName = i.FileName,
                                           Attachment_Path = i.FileName.Equals(string.Empty) ? string.Empty : string.Format("{0}://{1}{2}/upload files/{3}", rqVM.Shceme, rqVM.Host, rqVM.PathBase, i.FileName),
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
                                           UpdateDate = i.UpdateDate,
                                           Order = i.Order
                                       }).ToList();

                    var listIssueOrder = GetListIssueOrderByIdStage(stage.Id, sprint.Id);
                    // filter epic
                    if (rq.idEpic != null)
                    {
                        listIssueVM = listIssueVM.Where(i => i.Id_Parent_Issue.Equals(rq.idEpic)).Select(i => i).ToList();
                        listIssueOrder = listIssueOrder.Where(i => i.Id_Parent_Issue.Equals(rq.idEpic)).Select(i => i).ToList();
                    }

                    // filter type
                    if (rq.Type != null)
                    {
                        listIssueVM = listIssueVM.Where(i => i.Id_IssueType.Equals(rq.Type)).Select(i => i).ToList();
                        listIssueOrder = listIssueOrder.Where(i => i.Id_IssueType.Equals(rq.Type)).Select(i => i).ToList();
                    }

                    // add ListIssueOrder
                    stageVM.ListIssueOrder.AddRange(listIssueOrder.Select(i => i.Id));
                    // add ListIssue
                    stageVM.ListIssue.AddRange(listIssueVM);
                    listStageVM.Add(stageVM);
                }

                boardVM.ListStageOrder = listIdStageOrder;
                boardVM.ListStage = listStageVM;
                boardVM.ListEpic = _context.Issues.Where(i => i.Id_Project.Equals(sprint.Id_Project)
                                                            && i.Id_IssueType.Equals(EnumIssueType.Epic))
                                                  .Select(i => new Issue_ViewModel()
                                                  {
                                                      Id = i.Id,
                                                      Id_Project = i.Id_Project,
                                                      Id_IssueType = i.Id_IssueType,
                                                      Id_Stage = i.Id_Stage,
                                                      Id_Sprint = i.Id_Sprint,
                                                      Id_Label = i.Id_Label,
                                                      Summary = i.Summary,
                                                      Description = i.Description,
                                                      Id_Assignee = i.Id_Assignee,
                                                      Story_Point_Estimate = i.Story_Point_Estimate,
                                                      Id_Reporter = i.Id_Reporter,
                                                      FileName = i.FileName,
                                                      Attachment_Path = i.FileName.Equals(string.Empty) ? string.Empty : string.Format("{0}://{1}{2}/upload files/{3}", rqVM.Shceme, rqVM.Host, rqVM.PathBase, i.FileName),
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
                                                      UpdateDate = i.UpdateDate,
                                                      Order = i.Order
                                                  }).ToList();

                listBoardVM.Add(boardVM);
                return listBoardVM;
            }
            catch (Exception e)
            {
                _logger.LogInformation($"Controller: Issue. Method: GetInforBoardByIdSprint. Marvic Error: {e}");
                throw new MarvicException($"Error: {e}");
            }
        }
        public List<Issue> GetListIssueOrderByIdStage(Guid idStage, Guid idSprint)
        {
            try
            {
                var issues = _context.Issues.Where(i => i.Id_Stage.Equals(idStage)
                                                    && i.IsDeleted.Equals(EnumStatus.False)
                                                    && !i.Id_IssueType.Equals(EnumIssueType.Epic)
                                                    && i.Id_Sprint.Equals(idSprint))
                                            .OrderBy(i => i.Order)
                                            .Select(i => i).ToList();
                return issues;
            }
            catch (Exception e)
            {
                _logger.LogInformation($"Controller: Issue. Method: GetListIssueOrderByIdStage. Marvic Error: {e}");
                throw new MarvicException($"Error: {e}");
            }
        }
        public void UploadedFile(Guid idIssue, IFormFile file)
        {
            try
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
            catch (Exception e)
            {
                _logger.LogInformation($"Controller: Issue. Method: UploadedFile. Marvic Error: {e}");
                throw new MarvicException($"Error: {e}");
            }
        }
        public bool DeleteFileIssue(DeleteFile_Request rq)
        {
            try
            {
                var issue = Get_Issues_By_Id(rq.IdIssue);
                issue.FileName = string.Empty;
                return _context.SaveChanges() > 0;
            }
            catch (Exception e)
            {
                _logger.LogInformation($"Controller: Issue. Method: DeleteFileIssue. Marvic Error: {e}");
                throw new MarvicException($"Error: {e}");
            }
        }
        public Issue Get_Issues_By_Id(Guid idIssue)
        {
            try
            {
                var issue = _context.Issues.FirstOrDefault(i => i.Id.Equals(idIssue)
                                                            && i.IsDeleted.Equals(EnumStatus.False));
                return issue;
            }
            catch (Exception e)
            {
                _logger.LogInformation($"Controller: Issue. Method: Get_Issues_By_Id. Marvic Error: {e}");
                throw new MarvicException($"Error: {e}");
            }
        }
        public List<GroupByEpic_ViewModel> Group_By_Epic(Guid IdProject, RequestVM rq)
        {
            try
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
            catch (Exception e)
            {
                _logger.LogInformation($"Controller: Issue. Method: Group_By_Epic. Marvic Error: {e}");
                throw new MarvicException($"Error: {e}");
            }
        }
        public ListGroupByAssignee GroupIssueForBoardByAssignee(GetBoardIssue_Request rq, RequestVM rqVM)
        {
            try
            {
                // find Sprint
                var sprint = _context.Sprints.Find(rq.IdSprint);
                // get List Id Assignee in Sprint
                var listIdAssignee = _context.Issues.Where(i => i.Id_Sprint.Equals(sprint.Id)
                                                                && i.IsDeleted.Equals(EnumStatus.False))
                                                        .OrderBy(s => s.Order)
                                                        .Select(s => s.Id_Assignee).Distinct().ToList();
                // make issue unassignee to last
                listIdAssignee.Reverse();

                List<Assignee> lstAssignee = new List<Assignee>();
                foreach (var i_id in listIdAssignee)
                {
                    // get all stage id of Sprint and sort by order column
                    var lstStageOfSprint = GetAllStageByIdSprint(sprint).OrderBy(s => s.Order).Select(s => s.Id).ToList();

                    var listStageOfSprint = GetAllStageByIdSprint(sprint);
                    var listStageVM = new List<StageViewModel>();
                    foreach (var i_stageId in lstStageOfSprint)
                    {
                        // get list issue of assignee each stage in sprint and sort by order column
                        var listIssueOfAssignee = (from i in _context.Issues.ToList()
                                                   join s in _context.Stages.ToList() on i.Id_Stage equals s.Id
                                                   join spr in _context.Sprints.ToList() on i.Id_Sprint equals spr.Id
                                                   where i.IsDeleted.Equals(EnumStatus.False)
                                                       && !i.Id_IssueType.Equals(EnumIssueType.Epic)
                                                       && s.isDeleted.Equals(EnumStatus.False)
                                                       && s.Id.Equals(i_stageId)
                                                       && spr.Is_Archieved.Equals(EnumStatus.False)
                                                       && spr.Id_Project.Equals(s.Id_Project)
                                                       && spr.Id.Equals(rq.IdSprint)
                                                       && i.Id_Assignee.Equals(i_id)
                                                   orderby i.Order
                                                   select new Issue_ViewModel()
                                                   {
                                                       Id = i.Id,
                                                       Id_Project = i.Id_Project,
                                                       Id_IssueType = i.Id_IssueType,
                                                       Id_Stage = i.Id_Stage,
                                                       Id_Sprint = i.Id_Sprint,
                                                       Id_Label = i.Id_Label,
                                                       Summary = i.Summary,
                                                       Description = i.Description,
                                                       Id_Assignee = i.Id_Assignee,
                                                       Story_Point_Estimate = i.Story_Point_Estimate,
                                                       Id_Reporter = i.Id_Reporter,
                                                       FileName = i.FileName,
                                                       Attachment_Path = i.FileName.Equals(string.Empty) ? string.Empty : string.Format("{0}://{1}{2}/upload files/{3}", rqVM.Shceme, rqVM.Host, rqVM.PathBase, i.FileName),
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
                                                       UpdateDate = i.UpdateDate,
                                                       Order = i.Order
                                                   }).ToList();
                        // filter epic
                        if (rq.idEpic != null)
                            listIssueOfAssignee = listIssueOfAssignee.Where(i => i.Id_Parent_Issue.Equals(rq.idEpic)).Select(i => i).ToList();

                        // filter type
                        if (rq.Type != null)
                            listIssueOfAssignee = listIssueOfAssignee.Where(i => i.Id_IssueType.Equals(rq.Type)).Select(i => i).ToList();


                        var stageVM = _context.Stages.Where(s => s.Id.Equals(i_stageId))
                                                     .Select(s => new StageViewModel()
                                                     {
                                                         DateCreated = s.DateCreated,
                                                         Id = s.Id,
                                                         Id_Creator = s.Id_Creator,
                                                         Id_Project = s.Id_Project,
                                                         Order = s.Order,
                                                         Stage_Name = s.Stage_Name,
                                                         UpdateDate = s.UpdateDate,
                                                         ListIssue = listIssueOfAssignee,
                                                         ListIssueOrder = listIssueOfAssignee.Select(i => i.Id).ToList()
                                                     }).FirstOrDefault();
                        listStageVM.Add(stageVM);
                    }
                    // set infor for board
                    BoardViewModel boardVM = new BoardViewModel();
                    boardVM.ListStageOrder = lstStageOfSprint;
                    boardVM.ListStage = listStageVM;
                    boardVM.ListEpic = Get_Issues_By_IdSprint(sprint.Id, rqVM)
                                    .Where(i => i.Id_IssueType.Equals(EnumIssueType.Epic)).ToList();
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
            catch (Exception e)
            {
                _logger.LogInformation($"Controller: Issue. Method: GroupIssueForBoardByAssignee. Marvic Error: {e}");
                throw new MarvicException($"Error: {e}");
            }
        }
        public List<Stage> GetAllStageByIdSprint(Sprint sprint)
        {
            try
            {
                // get all stage id of Sprint
                var lstStageOfSprint = _context.Stages.Where(s => s.Id_Project.Equals(sprint.Id_Project)
                                                                    && s.isDeleted.Equals(EnumStatus.False)
                                                                    && sprint.Is_Archieved.Equals(EnumStatus.False))
                                                        .Select(s => s).ToList();
                return lstStageOfSprint;
            }
            catch (Exception e)
            {
                _logger.LogInformation($"Controller: Issue. Method: GetAllStageByIdSprint. Marvic Error: {e}");
                throw new MarvicException($"Error: {e}");
            }
        }
        public List<GroupWorkedOn_ViewModel> GetIssueForWorkedOn(Guid IdUserLogin, RequestVM rqVM)
        {
            try
            {
                WorkedOn_ViewModel workedOnVM = new WorkedOn_ViewModel();
                List<WorkedOn_ViewModel> listWorkedOnVM = new List<WorkedOn_ViewModel>();
                // lay ra issue lien quan den sprint isArchieve = false || ko thuoc ve sprint nao va ProjectName cua issue cho vao workedOnVM.ProjectName
                // lay ra ds nhung user lien quan den issue X cho vao workedOnVM.Users
                listWorkedOnVM = (from i in _context.Issues
                                  join spr in _context.Sprints on i.Id_Sprint equals spr.Id
                                  join p in _context.Projects on i.Id_Project equals p.Id
                                  join mem in _context.Members on p.Id equals mem.Id_Project
                                  join u in _context.App_Users on mem.Id_User equals u.Id
                                  where (u.Id.Equals(i.Id_Assignee)
                                    || u.Id.Equals(i.Id_Reporter)
                                    || u.Id.Equals(i.Id_Creator)
                                    || u.Id.Equals(i.Id_Updator))
                                    && u.Id.Equals(IdUserLogin)
                                    && spr.Is_Archieved.Equals(EnumStatus.False)
                                  select new WorkedOn_ViewModel()
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
                                      Attachment_Path = i.FileName.Equals(string.Empty) ? string.Empty : string.Format("{0}://{1}{2}/upload files/{3}", rqVM.Shceme, rqVM.Host, rqVM.PathBase, i.FileName),
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
                                      Order = i.Order,
                                      ProjectName = p.Name,
                                      Status = i.UpdateDate.Equals(DateTime.MinValue) ? "Created" : "Updated",
                                      Users = _context.App_Users.Where(ui => ui.Id.Equals(i.Id_Assignee)
                                                                            || ui.Id.Equals(i.Id_Reporter)
                                                                            || ui.Id.Equals(i.Id_Creator)
                                                                            || ui.Id.Equals(i.Id_Updator)
                                                                            && ui.Id.Equals(IdUserLogin))
                                                                .Select(u => new User_ViewModel()
                                                                {
                                                                    Id = u.Id,
                                                                    Department = u.Department,
                                                                    Email = u.Email,
                                                                    FullName = u.FullName,
                                                                    JobTitle = u.JobTitle,
                                                                    Organization = u.Organization,
                                                                    PhoneNumber = u.PhoneNumber,
                                                                    UserName = u.UserName,
                                                                    Avatar = u.Avatar,
                                                                    Avatar_Path = u.Avatar.Equals(string.Empty) ? string.Empty : string.Format("{0}://{1}{2}/upload files/Avatar/{3}", rqVM.Shceme, rqVM.Host, rqVM.PathBase, u.Avatar)
                                                                }).ToList()
                                  }).ToList();
                // gom nhom workedOnVM theo thang, sort giam dan 
                var group = listWorkedOnVM.GroupBy(i => i.DateCreated).OrderByDescending(i => i.Key).Select(i => i).ToList();
                List<GroupWorkedOn_ViewModel> listGroupWO_VM = new List<GroupWorkedOn_ViewModel>();
                foreach (var i_group in group)
                {
                    GroupWorkedOn_ViewModel groupWO_VM = new GroupWorkedOn_ViewModel();
                    groupWO_VM.Title = string.Format("{0}/{1}", i_group.Key.Value.Month, i_group.Key.Value.Year);
                    groupWO_VM.Items.AddRange(i_group);
                    listGroupWO_VM.Add(groupWO_VM);
                }

                return listGroupWO_VM;
            }
            catch (Exception e)
            {
                _logger.LogInformation($"Controller: Issue. Method: GetIssueForWorkedOn. Marvic Error: {e}");
                throw new MarvicException($"Error: {e}");
            }
        }
        public List<GroupAssignedTM_ViewModel> GetIssueAssignedToMe(Guid IdUserLogin, RequestVM rqVM)
        {
            try
            {
                List<GroupAssignedTM_ViewModel> listGroupAssignedTM_VM = new List<GroupAssignedTM_ViewModel>();
                // lấy ra các issue thuộc project kết hợp stage của issue
                var issues = (from i in _context.Issues
                              join p in _context.Projects on i.Id_Project equals p.Id
                              join s in _context.Stages on p.Id equals s.Id_Project
                              join mem in _context.Members on p.Id equals mem.Id_Project
                              join u in _context.App_Users on mem.Id_User equals u.Id
                              where i.Id_Stage.Equals(s.Id)
                                     && i.IsDeleted.Equals(EnumStatus.False)
                                     && i.Id_Assignee.Equals(IdUserLogin)
                                     && p.IsDeleted.Equals(EnumStatus.False)
                                     && s.isDefault.Equals(EnumStatus.False)
                                     && u.IsDeleted.Equals(EnumStatus.False)
                                     && u.Id.Equals(IdUserLogin)
                              select new AssignedToMe_ViewModel()
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
                                  Attachment_Path = i.FileName.Equals(string.Empty) ? string.Empty : string.Format("{0}://{1}{2}/upload files/{3}", rqVM.Shceme, rqVM.Host, rqVM.PathBase, i.FileName),
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
                                  Order = i.Order,
                                  ProjectName = p.Name,
                                  Status = s.Stage_Name
                              }).ToList();
                var group = issues.GroupBy(i => i.Status).Select(i => i).ToList();
                foreach (var i_group in group)
                {
                    var groupAssigned = new GroupAssignedTM_ViewModel();
                    groupAssigned.Title = i_group.Key;
                    groupAssigned.Items.AddRange(i_group);
                    listGroupAssignedTM_VM.Add(groupAssigned);
                }
                return listGroupAssignedTM_VM;
            }
            catch (Exception e)
            {
                _logger.LogInformation($"Controller: Issue. Method: GetIssueAssignedToMe. Marvic Error: {e}");
                throw new MarvicException($"Error: {e}");
            }
        }
        public List<IssueArchive_ViewModel> GetIssuesArchive(Guid idProject, RequestVM rqVM)
        {
            try
            {
                if (idProject != Guid.Empty)
                {
                    var listIssueArchiveVM = (from iss in _context.Issues
                         .AsEnumerable()
                                              join spr in _context.Sprints on iss.Id_Sprint equals spr.Id
                                              where spr.Id_Project == idProject && spr.Is_Archieved == EnumStatus.True
                                              orderby spr.End_Date descending
                                              group iss by new { spr.Id, spr.SprintName, spr.End_Date } into g
                                              select new IssueArchive_ViewModel
                                              {
                                                  SprintId = g.Key.Id,
                                                  SprintName = g.Key.SprintName,
                                                  EndDate = g.Key.End_Date.ToString("dd'/'MM'/'yyyy HH:mm:ss"),
                                                  Issues = g.Select(i => new Issue_ViewModel()
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
                                                      Attachment_Path = i.FileName.Equals(string.Empty) ? string.Empty : string.Format("{0}://{1}{2}/upload files/{3}", rqVM.Shceme, rqVM.Host, rqVM.PathBase, i.FileName),
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
                                                      Order = i.Order,
                                                      Users = _context.App_Users.Where(u => u.Id == i.Id_Updator || u.Id == i.Id_Creator || u.Id == i.Id_Assignee).Select(u => new User_ViewModel()
                                                      {
                                                          Department = u.Department,
                                                          Email = u.Email,
                                                          FullName = u.FullName,
                                                          Id = u.Id,
                                                          JobTitle = u.JobTitle,
                                                          Organization = u.Organization,
                                                          PhoneNumber = u.PhoneNumber,
                                                          UserName = u.UserName,
                                                          Avatar = u.Avatar,
                                                          Avatar_Path = u.Avatar.Equals(string.Empty) ? string.Empty : string.Format("{0}://{1}{2}/upload files/Avatar/{3}", rqVM.Shceme, rqVM.Host, rqVM.PathBase, u.Avatar)
                                                      }).ToList()
                                                  }).ToList()
                                              }).ToList();
                    return listIssueArchiveVM;
                }
                return null;
            }
            catch (Exception)
            {

                return null;
            }

        }
        public async Task<bool> ChangeStage(ChangeStage_Request rq)
        {
            try
            {
                var iss = await _context.Issues.FindAsync(rq.IdIssue);
                if (iss != null)
                {
                    iss.Id_Stage = rq.IdStage;
                    iss.UpdateDate = DateTime.Now;
                    iss.Id_Updator = rq.IdUpdator;
                    _context.Issues.Update(iss);
                    await _context.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                _logger.LogInformation($"Controller: Issue. Method: GetIssueAssignedToMe. Marvic Error: {e}");
                throw new MarvicException($"Error: {e}");
            }

        }

        public async Task<bool> AddLabel(IssueLabel_Request rq)
        {
            using (IDbContextTransaction tran = _context.Database.BeginTransaction())
            {
                try
                {
                    var issue = Get_Issues_By_Id(rq.IdIssue);
                    issue.Id_Label = rq.IdLabel;
                    _context.Update(issue);
                    await _context.SaveChangesAsync();
                    await tran.CommitAsync();
                    return true;
                }
                catch (Exception e)
                {
                    await tran.RollbackAsync();
                    _logger.LogInformation($"Controller: Issue. Method: AddLabel. Marvic Error: {e}");
                    throw new MarvicException($"Error: {e}");
                }
            }
        }

        public async Task<bool> RemoveLabel(Guid idIssue)
        {
            using (IDbContextTransaction tran = _context.Database.BeginTransaction())
            {
                try
                {
                    var issue = Get_Issues_By_Id(idIssue);
                    issue.Id_Label = Guid.Empty;
                    _context.Update(issue);
                    await _context.SaveChangesAsync();
                    await tran.CommitAsync();
                    return true;
                }
                catch (Exception e)
                {
                    await tran.RollbackAsync();
                    _logger.LogInformation($"Controller: Issue. Method: RemoveLabel. Marvic Error: {e}");
                    throw new MarvicException($"Error: {e}");
                }
            }
        }
    }
}
