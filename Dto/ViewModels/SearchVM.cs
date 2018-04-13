using Dto.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dto.ViewModels
{
    public class SearchVM
    {
        public string ArrivalAirportIata { get; set; }
        public string DestinationAirportIata { get; set; }
        public DateTime? DepartureDate { get; set; }
        public DateTime? ArrivalDate { get; set; }
        public int? NumberOfPassengers { get; set; }
        public Currency? Currency { get; set; }
    }
}
