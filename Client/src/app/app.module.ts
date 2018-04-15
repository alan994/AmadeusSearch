import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { AlertModule } from 'ngx-bootstrap';
import { BsDatepickerModule } from 'ngx-bootstrap/datepicker';

import { AppComponent } from './app.component';
import { FlightService } from './services/web-api/flight.service';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { CurrencyTextPipe } from './pipes/currency-text.pipe';
import { ListComponent } from './list/list.component';
import { NotFoundComponent } from './not-found/not-found.component';
import { ErrorComponent } from './error/error.component';
import { AppRoutingModule } from './app-routing.module';
import { UrlInterceptor } from './services/interceptors/url-interceptor.service';
import { Logger } from './services/utils/log.service';
import { CurrencyPipe } from '@angular/common';
import { ToastrModule } from 'ngx-toastr';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MinNumberValidator } from './directives/min-number.directive';

@NgModule({
	declarations: [
		AppComponent,
		CurrencyTextPipe,
		ListComponent,
		NotFoundComponent,
		MinNumberValidator,
		ErrorComponent
	],
	imports: [
		BrowserModule,
		FormsModule,
		BrowserAnimationsModule,
		HttpClientModule,

		AlertModule.forRoot(),
		BsDatepickerModule.forRoot(),
		ToastrModule.forRoot(),
		AppRoutingModule
	],
	providers: [
		FlightService,
		CurrencyPipe,
		Logger,
		{ provide: HTTP_INTERCEPTORS, useClass: UrlInterceptor, multi: true },		
	],
	bootstrap: [AppComponent]
})
export class AppModule { }
