using BidMyMechanic.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BidMyMechanic.Entities.Entities;
using BidMyMechanic.ViewModels.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace BidMyMechanic.Web.Controllers
{
    [Route("api/[Controller]")]
    [Authorize]
    public class BidsController: Controller
    {
        private readonly IBidService _bidService;
        private readonly ILogger<BidsController> _logger;
        private readonly IMapper _mapper;
        private readonly UserManager<BidUser> _userManager;

        public BidsController(IBidService bidService, ILogger<BidsController> logger, IMapper mapper, UserManager<BidUser> userManager)
        {
            _bidService = bidService;
            _logger = logger;
            _mapper = mapper;
            _userManager = userManager;
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

        [HttpGet("{id:int}")]
        public ActionResult Get(int id)
        {
            try
            {
                var bid = _mapper.Map<Bid, BidViewModel>(_bidService.GetBidById(id));
                if (bid != null) return Ok(bid);
                else return NotFound();

            }
            catch (Exception error)
            {
                _logger.LogError($"Failed to get the bid {id}, error {error}");
                return BadRequest($"Failed to get the bid with id {id}");
            }
        }

        // Every bid has only one issue
        [HttpGet("{id:int}/issue")]
        public ActionResult GetBidIssueById(int id)
        {
            try
            {
                var issue =_mapper.Map<Issue, IssueViewModel>(_bidService.GetBidRelateIssueById(id));
                return Ok(issue);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        [HttpGet("byUser")]
        public ActionResult GetBidsByUser(string user)
        {
            try
            {
                var userName = User.Identity.Name;
                var bids = _mapper.Map<IEnumerable<Bid>, IEnumerable<BidViewModel>>(_bidService.GetBidsByUser(userName));
                return Ok(bids);

            }
            catch (Exception e)
            {
                return BadRequest($"Failed to get Bids by User Name. Error: {e}" );
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody]BidViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var newBid = _mapper.Map<BidViewModel, Bid>(model);
                    newBid.BidUser = await _userManager.FindByNameAsync(User.Identity.Name);
                    if (_bidService.SaveEntity(newBid))
                    {
                        return Created($"/api/bids/{newBid.Id}", _mapper.Map<Bid, BidViewModel>(newBid));
                    }
                }
                

            }
            catch (Exception error)
            {
                _logger.LogError($"Failed to save bid: {error}");
                
            }
            return BadRequest($"Failed to save bid");
        }
    }
}
