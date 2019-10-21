using BidMyMechanic.Entities;
using BidMyMechanic.Services;
using BidMyMechanic.Services.Interfaces;

using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BidMyMechanic.Web.Controllers.Api
{
    public class BidController: Controller
    {
        private readonly IBidService _bidService;
        public BidController(IBidService bidService)
        {
            _bidService = bidService;
        }

        public IActionResult Index()
        {
            IEnumerable<Bid> bids = _bidService.GetAllBids();
            return View();
        }
    }
}
