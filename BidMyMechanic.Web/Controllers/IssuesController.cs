using System;
using BidMyMechanic.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BidMyMechanic.Web.Controllers
{
    [Route("api/[Controller]")]
    [Authorize]
    public class IssuesController : Controller
    {
        private readonly ILogger<IssuesController> _logger;
        private readonly IIssueService _issueService;

        public IssuesController(ILogger<IssuesController> logger, IIssueService issueService)
        {
            _logger = logger;
            _issueService = issueService;
        }

        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(_issueService.GetAll());
            }
            catch (Exception error)
            {
                _logger.LogError($"Failed to get Issues: {error}");
                return BadRequest("Failed to get Issues");
            }
            
        }
    }
}