import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import { SearchVM } from '../../models/search.model';
import { OptionVM } from '../../models/option.model';

@Injectable()
export class FlightService {

	constructor(private http: HttpClient){}

	searchFlight(search: SearchVM){
		return this.http.post<OptionVM[]>('/api/catalog', search);		
	}
}