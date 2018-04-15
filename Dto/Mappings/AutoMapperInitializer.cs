using AutoMapper;
using Dto.Models;
using Dto.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dto.Mappings
{
    public static class AutoMapperInitializer
    {
        public static void Initialize()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Search, SearchVM>()                
                .ReverseMap();
                cfg.CreateMap<Flight, FlightVM>().ReverseMap();

            });
        }                
    }
}
