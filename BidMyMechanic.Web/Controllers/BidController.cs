using BidMyMechanic.Entities;
using BidMyMechanic.Services;
using BidMyMechanic.Services.Interfaces;

using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BidMyMechanic.Entities.Entities;

namespace BidMyMechanic.Web.Controllers.Api
{
    public class BidController: Controller
    {
        private readonly IBidService _bidService;
        private readonly IVehicleService _vehicleService;


        public BidController(IBidService bidService, IVehicleService vehicleService)
        {
            _bidService = bidService;
            _vehicleService = vehicleService;
        }

        public IActionResult Index()
        {
            IEnumerable<Bid> bids = _bidService.GetAllBids();
            IEnumerable<Vehicle> vehicles = _vehicleService.GetAllVehicles();
            return View();
        }
    }
}
