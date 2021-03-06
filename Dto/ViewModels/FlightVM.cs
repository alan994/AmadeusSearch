﻿using Dto.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dto.ViewModels
{
    public class FlightVM
    {
        public int Id { get; set; }
        public DateTime DepartureDate { get; set; }
        public DateTime ArrivalDate { get; set; }
        public string DepartureAirportIata { get; set; }
        public string DestinationAirportIata { get; set; }
        public int NumberOfInterchanges { get; set; }
        public int NumberOfPassengers { get; set; }        
        public decimal PricePerAdult { get; set; }        
    }
}
