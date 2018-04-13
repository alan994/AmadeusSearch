using Dto.Enums;
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
        public AirportVM DepartureAirport { get; set; }
        public AirportVM ArrivalAirport { get; set; }
        public int NumberOfInterchanges { get; set; }
        public int NumberOfPassengers{ get; set; }
        public Currency Currency { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
