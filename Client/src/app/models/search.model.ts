import { Currency } from "./enums/currency.enum";

export class SearchVM {
	public originAirportIata: string;
	public destinationAirportIata: string;
	public departureDate: Date;
	public returnDate: Date;
	public numberOfPassengers: number;
	public currency: Currency;
}