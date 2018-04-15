using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Dto.Enums;
using Dto.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace Web.Services.Amadeus
{
    public class AmadeusApi : IFlightApi
    {
        private readonly IConfiguration configuration;

        public AmadeusApi(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task<List<Option>> GetFlights(Search search)
        {
            var url = this.ConstructUrl(search);
            var response = await this.GetResponseFromServer(url);
            return ParseResponse(response, search);
        }

        private List<Option> ParseResponse(string response, Search search)
        {
            List<Option> options = new List<Option>();

            dynamic jsonResponse = JsonConvert.DeserializeObject(response);

            foreach (var result in jsonResponse.results)
            {
                foreach (var itinerary in result.itineraries)
                {
                    Option option = new Option();
                    option.PricePerPerson = result.fare.price_per_adult.total_fare;
                    option.TotalPrice = result.fare.total_price;
                    option.Currency = search.Currency;

                    Flight outboundFlight = new Flight();
                    string departureDate = itinerary.outbound.flights[0].departs_at.ToString();
                    outboundFlight.DepartureDate = DateTime.Parse(departureDate);
                    outboundFlight.DepartureAirportIata = itinerary.outbound.flights[0].origin.airport;

                    outboundFlight.ArrivalDate = DateTime.Parse(itinerary.outbound.flights[itinerary.outbound.flights.Count - 1].arrives_at.ToString());
                    outboundFlight.DestinationAirportIata = itinerary.outbound.flights[itinerary.outbound.flights.Count - 1].destination.airport;

                    outboundFlight.NumberOfPassengers = search.NumberOfPassengers;
                    outboundFlight.NumberOfInterchanges = itinerary.outbound.flights.Count;


                    Flight inboundFlight = new Flight();
                    inboundFlight.DepartureDate = DateTime.Parse(itinerary.inbound.flights[0].departs_at.ToString());
                    inboundFlight.DepartureAirportIata = itinerary.inbound.flights[0].origin.airport;

                    inboundFlight.ArrivalDate = DateTime.Parse(itinerary.inbound.flights[itinerary.inbound.flights.Count - 1].arrives_at.ToString());
                    inboundFlight.DestinationAirportIata = itinerary.inbound.flights[itinerary.inbound.flights.Count - 1].destination.airport;

                    inboundFlight.NumberOfPassengers = search.NumberOfPassengers;
                    inboundFlight.NumberOfInterchanges = itinerary.inbound.flights.Count;

                    option.InboundFlight = inboundFlight;
                    option.OutboundFlight = outboundFlight;

                    options.Add(option);
                }

            }

            return options;
        }

        private string ConstructUrl(Search search)
        {
            var url = "https://api.sandbox.amadeus.com/v1.2/flights/low-fare-search?";

            #region Api key
            var apiKey = this.configuration["Data:api_key"];
            url += $"&apikey={apiKey}";
            #endregion

            #region Departure date
            var departureDate = search.DepartureDate.ToString("yyyy-MM-dd");
            url += $"&departure_date={departureDate}";
            #endregion

            #region Return date
            var returnDate = search.ReturnDate.ToString("yyyy-MM-dd");
            url += $"&return_date={returnDate}";
            #endregion

            #region Currency
            var currency = search.Currency.ToString();
            url += $"&currency={currency}";
            #endregion

            #region Number of passengers
            var numberOfPassengers = search.NumberOfPassengers;
            url += $"&adults={numberOfPassengers}";
            #endregion

            #region Destination airport IATA
            var destination = search.DestinationAirportIata;
            url += $"&destination={destination}";
            #endregion

            #region Origin airport IATA
            var origin = search.OriginAirportIata;
            url += $"&origin={origin}";
            #endregion

            return url;
        }

        private async Task<string> GetResponseFromServer(string url)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                //Retry logic 
                for (int i = 0; i < 3; i++)
                {
                    try
                    {
                        var response = await httpClient.GetStringAsync(url);
                        return response;
                    }
                    catch (Exception ex)
                    {
                        if(i == 2)
                        {
                            throw ex;
                        }
                    }
                }
            }

            return null;
        }
    }
}
