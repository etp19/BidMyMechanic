using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BidMyMechanic.Entities;
using BidMyMechanic.Entities.Entities;
using BidMyMechanic.Repositories.Interfaces;
using Microsoft.Extensions.Logging;

namespace BidMyMechanic.Repositories.Repositories
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly BidMyMechanicContext _dbContext;
        private readonly ILogger<VehicleRepository> _logger;

        public VehicleRepository(BidMyMechanicContext dbContext, ILogger<VehicleRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public IEnumerable<Vehicle> GetAllVehicles()
        {
            try
            {
                return _dbContext.Vehicles.Take(150).ToList();
            }
            catch (Exception error)
            {
                _logger.LogError($"Failed to get all vehicles: {error}");
                return null;
            }
            
        }

        public Vehicle GetVehicleById(int vehicleId)
        {
            try
            {
                return _dbContext.Vehicles.FirstOrDefault(car => car.Id == vehicleId);
            }
            catch (Exception error)
            {
                _logger.LogError($"Failed to get vehicle by id: {error}");
                return null;
            }
            
        }

        public IEnumerable<Vehicle> GetVehiclesByMake(string vehicleMake)
        {
            try
            {
                return _dbContext.Vehicles.Where(car => car.make == vehicleMake).Take(150).ToList();
            }
            catch (Exception error)
            {
                _logger.LogError($"Failed to get vehicle by make: {error}");
                return null;
            }
            
        }

        public IEnumerable<Vehicle> GetVehiclesByModel(string vehicleModel)
        {
            try
            {
                return _dbContext.Vehicles.Where(car => car.model == vehicleModel).Take(150).ToList();
            }
            catch (Exception error)
            {
                _logger.LogError($"Failed to get vehicle by model: {error}");
                return null;
            }
            
        }

        public IEnumerable<Vehicle> GetVehiclesByYear(string vehicleYear)
        {
            try
            {
                return _dbContext.Vehicles.Where(car => car.year == vehicleYear).Take(150).ToList();
            }
            catch (Exception error)
            {
                _logger.LogError($"Failed to get vehicle by year: {error}");
                return null;
            }
            
        }
    }
}
