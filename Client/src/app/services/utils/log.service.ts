import { Injectable } from '@angular/core';
import { ToastrService } from 'ngx-toastr';

@Injectable()
export class Logger {

	constructor(private toastr: ToastrService) { }

	info(msg: string, ...data: any[]) {
		console.info(msg, data);
		this.toastr.info(msg);
	}

	debug(msg: string, ...data: any[]) {
		console.log(msg, data);
	}

	success(msg: string, title?: string, ...data: any[]) {
		console.debug(msg, data);
		this.toastr.success(msg, title);
	}

	warning(msg: string, title?: string, ...data: any[]) {
		console.warn(msg, data);
		this.toastr.warning(msg, title);
	}

	error(msg: string, title?: string, ...data: any[]) {
		console.error(msg, data);
		this.toastr.error(msg, title);
	}
}
