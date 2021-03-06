﻿using Dto.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dto.ViewModels
{
    public class SearchVM
    {
        public string OriginAirportIata { get; set; }
        public string DestinationAirportIata { get; set; }
        public DateTime DepartureDate { get; set; } // Datum polaska
        public DateTime ReturnDate { get; set; } // Datum povratka
        public int NumberOfPassengers { get; set; }
        public Currency Currency { get; set; }
    }
}
