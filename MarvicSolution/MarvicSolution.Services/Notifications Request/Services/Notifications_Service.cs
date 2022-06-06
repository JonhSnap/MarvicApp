using MarvicSolution.DATA.EF;
using MarvicSolution.DATA.Entities;
using MarvicSolution.DATA.Enums;
using MarvicSolution.Services.Answer_Request.Requests;
using MarvicSolution.Services.Answer_Request.ViewModels;
using MarvicSolution.Services.Notifications_Request.ViewModels;
using MarvicSolution.Services.Project_Request.Project_Resquest;
using MarvicSolution.Utilities.Exceptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarvicSolution.Services.Notifications_Request.Services
{
    public class Notifications_Service : INotifications_Service
    {
        private readonly MarvicDbContext _context;
        private readonly ILogger<Notifications_Service> _logger;
        public Notifications_Service(MarvicDbContext context)
        {
            _context = context;
        }

        public Notifications Create(Guid idItemRef, string mess, int isProject, int isIssue)
        {
            try
            {
                var notif = new Notifications(idItemRef, mess, isProject, isIssue);
                _context.Notifications.Add(notif);
                _context.SaveChanges();
                return notif;
            }
            catch (Exception e)
            {
                _logger.LogInformation($"Controller: Notification. Method: Create. Marvic Error: {e}");
                throw new MarvicException($"Error: {e}");
            }
        }

        public async Task<GetNotification_ViewModel> Get(Guid idUser)
        {
            try
            {
                var notifs = await (from n in _context.Notifications
                                    join nu in _context.Notif_Users on n.Id equals nu.IdNotif
                                    where nu.IdUser.Equals(idUser)
                                    select new Notification_ViewModel()
                                    {
                                        IdItemRef = n.IdItemRef,
                                        Date = n.Date,
                                        Message = n.Message,
                                        IsView = nu.IsView,
                                        IsProject = n.IsProject,
                                        IsIssue = n.IsIssue
                                    }).ToListAsync();

                var countUnView = notifs.Where(n => n.IsView.Equals(EnumStatus.False)).Count();
                GetNotification_ViewModel listNotif = new GetNotification_ViewModel(countUnView, notifs);
                return listNotif;
            }
            catch (Exception e)
            {
                _logger.LogInformation($"Controller: Notification. Method: Get. Marvic Error: {e}");
                throw new MarvicException($"Error: {e}");
            }
        }

        public void PSS_SendNotif(Guid idProject, Guid idUserAction, string mess)
        {
            // create and send notif 
            List<Guid> listMemberId = GetAllMembersByIdProject(idProject).Select(mem => mem.Id).ToList();
            // not send notif for user who made this action
            listMemberId = listMemberId.Except(new List<Guid>() { idUserAction }).ToList();
            SendNotif(idProject, mess, listMemberId, 1,0);
        }

        public void IssueSendNotif(Guid idItemRef, List<Guid> listIdUserInvolve, Guid idUserAction, string mess)
        {
            // create and send notif 
            // not send notif for user who made this action
            listIdUserInvolve = listIdUserInvolve.Except(new List<Guid>() { idUserAction }).ToList();
            SendNotif(idItemRef, mess, listIdUserInvolve, 0, 1);
        }

        public void SendNotif(Guid idItemRef, string mess, List<Guid> listUser, int isProject, int isIssue)
        {
            // add many Notif_Users
            try
            {
                var notif = Create(idItemRef, mess, isProject, isIssue);
                foreach (var i_user in listUser)
                {
                    var notifUser = new Notif_User(notif.Id, i_user);
                    _context.Notif_Users.Add(notifUser);
                }
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                _logger.LogInformation($"Controller: Notification. Method: SendNotif. Marvic Error: {e}");
                throw new MarvicException($"Error: {e}");
            }
        }

        public async Task<bool> Viewed(Guid idNotif, Guid idUser)
        {
            using (IDbContextTransaction tran = _context.Database.BeginTransaction())
            {
                try
                {
                    var notifUser = await _context.Notif_Users.SingleOrDefaultAsync(nu => nu.IdNotif.Equals(idNotif)
                                                                                    && nu.IdUser.Equals(idUser));
                    if (notifUser != null)
                    {
                        notifUser.IsView = EnumStatus.True;
                        await _context.SaveChangesAsync();
                        await tran.CommitAsync();
                        return true;
                    }
                    return false;
                }
                catch (Exception e)
                {
                    _logger.LogInformation($"Controller: Notification. Method: Viewed. Marvic Error: {e}");
                    throw new MarvicException($"Error: {e}");
                    await tran.RollbackAsync();
                }
            }
        }

        private List<App_User> GetAllMembersByIdProject(Guid idProject)
        {
            try
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
            catch (Exception e)
            {
                _logger.LogInformation($"Controller: Notifications. Method: GetAllMembersByIdProject. Marvic Error: {e}");
                throw new MarvicException($"Error: {e}");
            }
        }
    }
}
