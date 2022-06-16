using MarvicSolution.DATA.Entities;
using MarvicSolution.Services.Notifications_Request.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MarvicSolution.Services.Notifications_Request.Services
{
    public interface INotifications_Service
    {
        Task<bool> Viewed(Guid idNotif, Guid idUser);
        Task<GetNotification_ViewModel> Get(Guid idUser);
        void SendNotif(Guid idItemRef, string mess, List<Guid> listUser, int isProject, int isIssue);
        void PSS_SendNotif(Guid idProject, Guid idUserAction, string mess); // Project, Sprint, Stage send notif
        void IssueSendNotif(Guid idItemRef, List<Guid> listIdUserInvolve, Guid idUserAction, string mess);

    }
}
