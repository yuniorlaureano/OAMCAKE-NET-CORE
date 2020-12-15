using AutoMapper;
using OamCake.Data.Dto;
using OamCake.Data.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace OamCake.Data.MappingProfile
{
    public class SupplyMapping : Profile
    {
        public SupplyMapping()
        {
            CreateMap<Supply, SupplyDto>();
            CreateMap<SupplyDto, Supply>();
        }
    }
}
