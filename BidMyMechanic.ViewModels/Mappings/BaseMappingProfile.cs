using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using BidMyMechanic.Entities.Entities;
using BidMyMechanic.ViewModels.ViewModels;

namespace BidMyMechanic.ViewModels.Mappings
{
    public class BaseMappingProfile: Profile
    {
        public BaseMappingProfile()
        {
            CreateMap<Bid, BidViewModel>().ReverseMap();
        }
    }
}
