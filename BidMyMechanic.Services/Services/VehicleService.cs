using System.Collections.Generic;
using BidMyMechanic.Entities.Entities;
using BidMyMechanic.Repositories.Interfaces;
using BidMyMechanic.Services.Interfaces;

namespace BidMyMechanic.Services.Services
{
    public class VehicleService: IVehicleService
    {
        private readonly IVehicleRepository _vehicleRepository;

        public VehicleService(IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }
        public IEnumerable<Vehicle> GetAllVehicles()
        {
            return _vehicleRepository.GetAllVehicles();
        }
    }
}