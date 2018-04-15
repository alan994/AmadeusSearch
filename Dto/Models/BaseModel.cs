using System;
using System.Collections.Generic;
using System.Text;

namespace Dto.Models
{
    public class BaseModel
    {
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
