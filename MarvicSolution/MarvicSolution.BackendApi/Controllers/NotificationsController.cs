using MarvicSolution.BackendApi.Constants;
using MarvicSolution.BackendApi.Hubs;
using MarvicSolution.Services.Notifications_Request.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarvicSolution.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationsController : ControllerBase
    {
        private readonly INotifications_Service _notifService;
        private readonly IHubContext<ActionHub, IActionHub> _actionHub;
        public NotificationsController(INotifications_Service notifService, IHubContext<ActionHub, IActionHub> actionHub)
        {
            _notifService = notifService;
            _actionHub = actionHub;
        }

        [HttpGet]
        [Route("/api/Notifications/Get")]
        public async Task<IActionResult> Get()
        {
            var result = await _notifService.Get(UserLogin.Id);
            await _actionHub.Clients.All.Notif();
            return Ok(result);
        }

        [HttpPatch]
        [Route("/api/Notifications/Viewed")]
        public async Task<IActionResult> Viewed(Guid idNotif)
        {
            var result = await _notifService.Viewed(idNotif, UserLogin.Id);
            return Ok(result);
        }


    }
}
