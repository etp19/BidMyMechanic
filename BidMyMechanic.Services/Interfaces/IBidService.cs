﻿using System.Collections.Generic;
using BidMyMechanic.Entities.Entities;

namespace BidMyMechanic.Services.Interfaces
{
    public interface IBidService
    {
        IEnumerable<Bid> GetAll();
    }
}
