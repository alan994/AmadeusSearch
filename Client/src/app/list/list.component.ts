import { Component, OnInit } from '@angular/core';
import { SearchVM } from '../models/search.model';
import { FlightService } from '../services/web-api/flight.service';
import { Currency } from '../models/enums/currency.enum';
import { OptionVM } from '../models/option.model';
import { HttpErrorResponse } from '@angular/common/http';
import { Logger } from '../services/utils/log.service';
import { IataService } from '../services/web-api/iata.service';


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
	public iataCodes: string[];
	public today = new Date();
	
	constructor(private flightService: FlightService, private logger: Logger, iataService: IataService) { 
		this.iataCodes = iataService.getCodes();
	}
	
	search() {
		this.isLoading = true;
		this.data = [];
		this.flightService.searchFlight(this.searchModel).subscribe((response) => {
			this.data = response;
			this.isLoading = false;
		}, (response: HttpErrorResponse) => {
			this.isLoading = false;
			this.logger.error(response.error, 'Error!');
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
