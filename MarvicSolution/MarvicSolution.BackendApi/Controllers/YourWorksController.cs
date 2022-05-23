using MarvicSolution.DATA.Common;
using MarvicSolution.DATA.EF;
using MarvicSolution.Services.Issue_Request.Dtos.ViewModels;
using MarvicSolution.Services.Issue_Request.Issue_Request;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarvicSolution.BackendApi.Controllers
{
    public class YourWorksController : Controller
    {
        // Must declare DI in startup
        private readonly IIssue_Service _issueService;
        private readonly MarvicDbContext _context;

        public YourWorksController(IIssue_Service issueService, MarvicDbContext context)
        {
            _issueService = issueService;
            _context = context;
        }

        // /api/WorkedOn
        [HttpGet]
        [Route("/api/WorkedOn")]
        public IActionResult WorkedOn()
        {
            RequestVM rqVM = new RequestVM(Request.Scheme, Request.Host, Request.PathBase);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var wo = _issueService.GetIssueForWorkedOn(UserLogin.Id, rqVM);
            if (wo == null)
                return BadRequest($"Cannot get issue by UserID = {UserLogin.Id}");

            _context.SaveChanges();
            return Ok(wo);
        }
    }
}
