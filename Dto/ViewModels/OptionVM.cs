using Dto.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dto.ViewModels
{
    public class OptionVM
    {
        public decimal TotalPrice { get; set; }
        public decimal PricePerPerson { get; set; }
        public Currency Currency { get; set; }
        public FlightVM OutboundFlight { get; set; }        
        public FlightVM InboundFlight { get; set; }
    }
}
