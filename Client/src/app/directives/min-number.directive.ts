import { Validator, ValidatorFn, FormControl, NG_VALIDATORS } from "@angular/forms";
import { Input, Directive, forwardRef, Attribute } from "@angular/core";

@Directive({
	selector: `[validateMinNumber][formControlName],[validateMinNumber] [formControl],[validateMinNumber][ngModel]`,
	providers: [{ provide: NG_VALIDATORS, useExisting: MinNumberValidator, multi: true }]
  })
export class MinNumberValidator implements Validator {
	
	constructor(@Attribute('validateMinNumber') public minValue: number) {
		
	}
	
	validate(c: FormControl): ValidatorFn {
		return (c: FormControl) => {
			if (isNaN(c.value)) {
				return { minNumberValidator: { valid: false } };
			}
			var value: number = c.value;
			if(value < this.minValue) {
				return { minNumberValidator: { valid: false} };
			}			
			else{
				return null;
			}
		}
	}
}