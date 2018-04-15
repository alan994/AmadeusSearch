using Dto.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Dto.Models
{
    public class Flight: BaseModel
    {
        public int Id { get; set; }
        public DateTime DepartureDate { get; set; }
        public DateTime ArrivalDate { get; set; }
        public string DepartureAirportIata { get; set; }
        public string DestinationAirportIata { get; set; }
        public int NumberOfInterchanges { get; set; }
        public int NumberOfPassengers { get; set; }        
    }
}
