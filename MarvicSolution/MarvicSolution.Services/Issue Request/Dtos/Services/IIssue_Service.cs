
using MarvicSolution.Services.Issue_Request.Dtos.ViewModels;
using MarvicSolution.Services.Issue_Request.Issue_Request.Dtos;
using MarvicSolution.Services.Issue_Request.Issue_Request.Dtos.ViewModels;
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
        List<Issue_ViewModel> Get_Issues_By_IdProject(Guid idProject);
        List<Issue_ViewModel> Get_Issues_By_IdUser(Guid idProject, Guid idUser);
        List<GroupByAssignee_ViewModel> Group_By_Assignee(Guid IdProject);
        List<GroupByIssueType_ViewModel> Group_By_IssueType(Guid IdProject);
        List<GroupByPriority_ViewModel> Group_By_Priority(Guid IdProject);
        List<Issue_ViewModel> Get_Issue_By_IdParent(Guid IdProject, Guid IdParent);
        List<Issue_ViewModel> Get_Issue_By_IdLabel(Guid IdProject, Guid IdLabel);

    }
}
