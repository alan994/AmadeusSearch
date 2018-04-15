import { Component, OnInit } from '@angular/core';
import { SearchVM } from '../models/search.model';
import { FlightService } from '../services/web-api/flight.service';
import { Currency } from '../models/enums/currency.enum';
import { OptionVM } from '../models/option.model';
import { HttpErrorResponse } from '@angular/common/http';
import { Logger } from '../services/utils/log.service';


@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.css']
})
export class ListComponent implements OnInit {


	public searchModel = new SearchVM();
	public currency = Currency;
	public data: OptionVM[];
	public isLoading = false;
	constructor(private flightService: FlightService, private logger: Logger) { }
	
	search() {
		this.isLoading = true;
		this.data = [];
		this.flightService.searchFlight(this.searchModel).subscribe((response) => {
			this.data = response;
			this.isLoading = false;
		}, (response: HttpErrorResponse) => {
			this.isLoading = false;
			this.logger.error('Error occurred, try again!');
		});
	}
	
	ngOnInit(): void {
		this.searchModel = new SearchVM();
		this.searchModel.numberOfPassengers = 1;
		this.searchModel.currency = Currency.HRK;
		this.searchModel.departureDate = new Date();
	}

	departureDateChange(departureDate: Date){
		if(this.searchModel.returnDate && this.searchModel.returnDate.getTime() < departureDate.getTime()){
			this.searchModel.returnDate = null;
		}
	}
}
