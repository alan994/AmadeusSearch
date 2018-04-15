using Dto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Services
{
    public interface IFlightApi
    {
        Task<List<Option>> GetFlights(Search search);
    }
}
