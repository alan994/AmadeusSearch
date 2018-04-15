using Dto.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Dto.Models
{
    public class Search: BaseModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string OriginAirportIata { get; set; }
        public string DestinationAirportIata { get; set; }
        [Column(TypeName = "date")]
        public DateTime DepartureDate { get; set; } // Datum polaska
        [Column(TypeName = "date")]
        public DateTime ReturnDate { get; set; } // Datum povratka
        public int NumberOfPassengers { get; set; }
        public Currency Currency { get; set; }
    }
}
