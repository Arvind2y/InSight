import { Directive } from '@angular/core';
import { Validator, AbstractControl, NG_VALIDATORS } from '@angular/forms';

@Directive({
  selector: '[appSelectValidator]',
  providers: [{
    provide: NG_VALIDATORS,
    useExisting: SelectRequiredValidatorDirective,
    multi: true
  }]
})
export class SelectRequiredValidatorDirective implements Validator {

  constructor() { }

  // AbstractControl : is base class of formcontrol and formgroup control
  validate(control: AbstractControl): { [key: string]: any } | null {
    return control.value === '0' ? { 'defaultSelected': true } : null;
  }

}
