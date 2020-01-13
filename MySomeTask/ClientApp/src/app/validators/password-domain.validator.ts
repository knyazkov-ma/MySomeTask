import { Directive, Injector, ReflectiveInjector } from '@angular/core';
import { NG_ASYNC_VALIDATORS, NG_VALIDATORS, FormControl, AsyncValidator, ValidationErrors } from '@angular/forms';
import { FormDataService } from '../data/formData.service';
import { Observable } from "rxjs";
import { map, debounceTime, take, switchMap } from "rxjs/operators";

@Directive({
  selector: '[passwordDomain][ngModel]',
  providers: [
    {
      provide: NG_ASYNC_VALIDATORS,
      useExisting: PasswordDomainValidator,
      multi: true
    }
  ]
})
export class PasswordDomainValidator implements AsyncValidator {
  constructor(private formDataService: FormDataService) {

  }

  validate(control: FormControl): Promise<ValidationErrors | null> | Observable<ValidationErrors | null> {
    let password = control.value;
    

    if (!password)
      return null;

    return this.formDataService.getPasswordValidationFromServer(password)
      .pipe(
        map(res => {
          // if username is already taken
          if (res) {
            // return error
            return res;
          }

          return null;
        })
      );    
  }  
}
