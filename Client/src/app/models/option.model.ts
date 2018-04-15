import { FlightVM } from "./flight.model";
import { Currency } from "./enums/currency.enum";

export class OptionVM{
	public totalPrice: number;
	public pricePerPerson: number;
	public currency: Currency;
	public outboundFlight: FlightVM;
	public inboundFlight: FlightVM;
}