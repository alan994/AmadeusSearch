using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dto.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Web.Services;

namespace Web.Controllers
{
    [Route("api/catalog")]
    public class CatalogController : Controller
    {
        private readonly CatalogService catalogService;
        private readonly ILogger<CatalogController> logger;

        public CatalogController(CatalogService catalogService, ILogger<CatalogController> logger)
        {
            this.catalogService = catalogService;
            this.logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var resultList = new List<FlightVM>()
            {
                new FlightVM()
                {
                    Id = 1,
                    ArrivalAirport = new AirportVM()
                    {
                        Id = 1,
                        Iata = "df",
                        Name = "JFK"
                    },
                    ArrivalDate = DateTime.UtcNow,
                    Currency = Dto.Enums.Currency.EUR,
                    DepartureAirport = new AirportVM()
                    {
                        Id = 2,
                        Iata = "aafasd",
                        Name = "Franjo tuđman"
                    },
                    DepartureDate = DateTime.UtcNow.AddHours(10),
                    NumberOfInterchanges = 2,
                    NumberOfPassengers = 60,
                    TotalPrice = 1232m
                }
            };

            return Json(resultList);
        }     
    }
}
