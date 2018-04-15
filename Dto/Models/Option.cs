using Dto.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Dto.Models
{
    public class Option: BaseModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int SearchId { get; set; }
        public int OutboundFlightId { get; set; }
        public int InboundFlightId { get; set; }
        public Currency Currency { get; set; }

        public decimal TotalPrice { get; set; }
        public decimal PricePerPerson { get; set; }

        [ForeignKey("SearchId")]
        public virtual Search Search { get; set; }

        [ForeignKey("OutboundFlightId")]
        public virtual Flight OutboundFlight { get; set; }
        [ForeignKey("InboundFlightId")]
        public virtual Flight InboundFlight { get; set; }
    }
}
