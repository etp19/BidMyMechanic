using BidMyMechanic.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using AutoMapper;
using BidMyMechanic.Entities.Entities;
using BidMyMechanic.ViewModels.ViewModels;
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
        private readonly IMapper _mapper;


        public BidsController(IBidService bidService, ILogger<BidsController> logger, IMapper mapper)
        {
            _bidService = bidService;
            _logger = logger;
            _mapper = mapper;
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
                return Ok(_bidService.GetBidRelateIssueById(id));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        [HttpPost]
        public ActionResult Post([FromBody]BidViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var newBid = _mapper.Map<BidViewModel, Bid>(model);
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
