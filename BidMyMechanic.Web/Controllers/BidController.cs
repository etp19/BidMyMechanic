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
        private readonly BidMyMechanicContext _bidMyMechanicContext;

        public BidController(IBidService bidService, BidMyMechanicContext bidMyMechanicContext)
        {
            _bidService = bidService;
            _bidMyMechanicContext = bidMyMechanicContext;
        }

        public IActionResult Index()
        {
            IEnumerable<Bid> bids = _bidService.GetAllBids();
            var result = _bidMyMechanicContext.Issues.ToList();
            return View();
        }
    }
}
