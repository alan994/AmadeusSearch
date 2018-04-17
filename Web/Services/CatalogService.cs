using AutoMapper;

using Dao;
using Dto.Models;
using Dto.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Services
{
    public class CatalogService
    {
        private readonly IFlightApi flightApi;
        private readonly AmadeusContext db;
        private readonly ILogger<CatalogService> logger;
        private readonly IConfiguration configuration;

        public CatalogService(IFlightApi flightApi, AmadeusContext db, ILogger<CatalogService> logger, IConfiguration configuration)
        {
            this.flightApi = flightApi;
            this.db = db;
            this.logger = logger;
            this.configuration = configuration;
        }

        public async Task<List<OptionVM>> GetFlights(SearchVM searchVM)
        {
            var search = Mapper.Map<Search>(searchVM);

            var resultFromDb = await this.SearchLocalFlights(search);

            if (resultFromDb != null && resultFromDb.Count != 0)
            {
                this.logger.LogInformation("Data found locally");
                return convertResultToVM(resultFromDb, search);
            }

            this.logger.LogInformation("Retrieving data from API");
            var resultFromApi = await this.flightApi.GetFlights(search);

            this.logger.LogInformation("Saving data to local DB");
            await this.SaveFlightsToDb(resultFromApi, search);

            return convertResultToVM(resultFromApi, search);            
        }

        private List<OptionVM> convertResultToVM(List<Option> resultFromApi, Search search)
        {
            List<OptionVM> result = new List<OptionVM>();
                        
            foreach (var option in resultFromApi)
            {
                OptionVM vm = new OptionVM();
                vm.TotalPrice = option.TotalPrice;
                vm.PricePerPerson = option.PricePerPerson;
                vm.Currency = option.Currency;
                vm.OutboundFlight = Mapper.Map<FlightVM>(option.OutboundFlight);
                vm.InboundFlight = Mapper.Map<FlightVM>(option.InboundFlight);

                result.Add(vm);
            }

            return result;
        }

        private async Task SaveFlightsToDb(List<Option> options, Search search)
        {
            if(options == null || options.Count == 0)
            {
                return;
            }

            await this.db.Searches.AddAsync(search);

            foreach (var option in options)
            {
                option.SearchId = search.Id;
                await this.db.Options.AddAsync(option);
            }

            await this.db.SaveChangesAsync();
        }

        private async Task<List<Option>> SearchLocalFlights(Search search)
        {
            var minutes = int.Parse(this.configuration["MaxAgeOfData"]);
            DateTime maxAgeOfData = DateTime.UtcNow.AddMinutes(minutes * -1);

            var resultList = await this.db.Options
                .Where(x => x.Search.DestinationAirportIata == search.DestinationAirportIata
                    && x.Search.OriginAirportIata == search.OriginAirportIata
                    && x.Search.ReturnDate == search.ReturnDate
                    && x.UpdatedOn > maxAgeOfData
                    && x.Search.DepartureDate == search.DepartureDate
                    && x.Search.NumberOfPassengers == search.NumberOfPassengers
                    && x.Search.Currency == search.Currency)
                .Include(x => x.OutboundFlight)
                .Include(x => x.InboundFlight)
                .ToListAsync();
            
            return resultList;
        }
    }
}
