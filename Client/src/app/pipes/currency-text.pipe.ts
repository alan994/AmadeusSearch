import { Pipe, PipeTransform } from "@angular/core";
import { Currency } from "../models/enums/currency.enum";
import { CurrencyPipe } from "@angular/common";

@Pipe({
	name: 'currencyText'
})
export class CurrencyTextPipe implements PipeTransform {

	constructor(private currencyPipe: CurrencyPipe) { }

	transform(value: number, ...args: Currency[]) {

		switch (args[0]) {
			case Currency.EUR: {
				return this.currencyPipe.transform(value, 'EUR');
			}
			case Currency.HRK: {
				return this.currencyPipe.transform(value, 'HRK');
			}
			case Currency.USD: { 
				return this.currencyPipe.transform(value, 'USD'); 
			}
		}
	}
}