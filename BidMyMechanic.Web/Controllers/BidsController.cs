using BidMyMechanic.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.Extensions.Logging;

namespace BidMyMechanic.Web.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    [Produces("application/json")]
    public class BidsController: Controller
    {
        private readonly IBidService _bidService;
        private readonly ILogger<BidsController> _logger;


        public BidsController(IBidService bidService, ILogger<BidsController> logger)
        {
            _bidService = bidService;
            _logger = logger;
        }

        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(_bidService.GetAll());
            }
            catch (Exception error)
            {
                _logger.LogError($"Failed to get bids {error}");
                return BadRequest("Failed to get bids");
            }
        }
    }
}
