using System;
using BidMyMechanic.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BidMyMechanic.Web.Controllers
{
    [Route("api/[Controller]")]
    [Authorize]
    public class IssueTrackingController: Controller
    {
        private readonly IIssueTrackingService _issueTrackingService;
        private readonly ILogger<IssueTrackingController> _logger;

        public IssueTrackingController(IIssueTrackingService issueTrackingService, ILogger<IssueTrackingController> logger)
        {
            _issueTrackingService = issueTrackingService;
            _logger = logger;
        }

        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(_issueTrackingService.GetAll());
            }
            catch (Exception error)
            {
                _logger.LogError($"Failed to get Issue Tracking: {error}");
                return BadRequest("Failed to get Issue Tracking");
            }
        }
    }
}
