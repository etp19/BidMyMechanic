using System;
using System.Collections.Generic;
using BidMyMechanic.Entities.Entities;
using BidMyMechanic.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BidMyMechanic.Web.Controllers
{
    [Route("api/[Controller]")]
    [Authorize]
    public class VehicleController: Controller
    {
        private readonly IVehicleService _vehicleService;
        private readonly ILogger<VehicleController> _logger;

        public VehicleController(IVehicleService vehicleService, ILogger<VehicleController> logger)
        {
            _vehicleService = vehicleService;
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Vehicle>> Get()
        {
            try
            {
                return Ok(_vehicleService.GetAllVehicles());
            }
            catch (Exception error)
            {
                _logger.LogError($"Failed to get vehicles: {error}");
                return BadRequest("Failed to get vehicles");
            }
            
        }
    }
}
