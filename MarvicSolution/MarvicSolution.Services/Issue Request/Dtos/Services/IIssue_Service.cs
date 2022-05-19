
using MarvicSolution.DATA.Entities;
using MarvicSolution.Services.Issue_Request.Dtos.Requests;
using MarvicSolution.Services.Issue_Request.Dtos.ViewModels;
using MarvicSolution.Services.Issue_Request.Dtos.ViewModels.Board;
using MarvicSolution.Services.Issue_Request.Issue_Request.Dtos;
using MarvicSolution.Services.Issue_Request.Issue_Request.Dtos.ViewModels;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvicSolution.Services.Issue_Request.Issue_Request
{
    public interface IIssue_Service
    {
        // INPUT
        Task<Guid> Create(Issue_CreateRequest rq);
        Task<Guid> Update(Issue_UpdateRequest request);
        Task<Guid> Delete(Guid Id);

        // OUTPUT
        Issue Get_Issues_By_Id(Guid idIssue);
        List<Issue_ViewModel> Get_Issues_By_IdProject(Guid idProject, RequestVM rq);
        List<Issue_ViewModel> Get_Issues_By_IdUser(Guid idProject, Guid idUser, RequestVM rq);
        List<Issue_ViewModel> Get_Issue_By_IdParent(Guid IdProject, Guid IdParent, RequestVM rq);
        List<Issue_ViewModel> Get_Issue_By_IdLabel(Guid IdProject, Guid IdLabel, RequestVM rq);
        List<Issue_ViewModel> Get_Issues_By_IdSprint(Guid idSprint, RequestVM rq);
        List<Issue_ViewModel> Get_Issues_NotInSprint_By_IdProject(Guid idProject, RequestVM rq);
        List<GroupByAssignee_ViewModel> Group_By_Assignee(Guid IdProject, RequestVM rq);
        List<GroupByIssueType_ViewModel> Group_By_IssueType(Guid IdProject, RequestVM rq);
        List<GroupByPriority_ViewModel> Group_By_Priority(Guid IdProject, RequestVM rq);
        List<GroupByProject_ViewModel> Group_By_IdUser(Guid IdUser, RequestVM rq);
        List<GroupByEpic_ViewModel> Group_By_Epic(Guid IdProject, RequestVM rq);
        List<BoardViewModel> GetInforBoardByIdSprint(Guid IdSprint, RequestVM rq);
        List<Guid> GetListIssueOrderByIdStage(Guid idStage, Guid idSprint);
        void UploadedFile(Guid idIssue, IFormFile file);
        bool DeleteFileIssue(DeleteFile_Request rq);
        ListGroupByAssignee GroupIssueForBoardByAssignee(Guid IdSprint, RequestVM rq);

    }
}
