import { Currency } from "./enums/currency.enum";

export class FlightVM {
	public id: number;
	public departureDate: Date;
	public arrivalDate: Date;
	public departureAirportIata: string;
	public destinationAirportIata: string;
	public numberOfInterchanges: number;
	public numberOfPassengers: number;
	public currency: Currency;		
}