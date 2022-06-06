using MarvicSolution.BackendApi.Constants;
using MarvicSolution.Services.Notifications_Request.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        public NotificationsController(INotifications_Service notifService)
        {
            _notifService = notifService;
        }

        [HttpGet]
        [Route("/api/Notifications/Get")]
        public async Task<IActionResult> Get()
        {
            var result = await _notifService.Get(UserLogin.Id);
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
