import { Directive } from '@angular/core';
import { NG_ASYNC_VALIDATORS, FormControl, AsyncValidator, ValidationErrors } from '@angular/forms';
import { FormDataService } from '../data/formData.service';
import { Observable } from "rxjs";
import { map } from "rxjs/operators";

@Directive({
  selector: '[emailDomain][ngModel]',
  providers: [
    {
      provide: NG_ASYNC_VALIDATORS,
      useExisting: EmailDomainValidator,
      multi: true
    }
  ]
})
export class EmailDomainValidator implements AsyncValidator {
  constructor(private formDataService: FormDataService) {

  }

  validate(control: FormControl): Promise<ValidationErrors | null> | Observable<ValidationErrors | null> {
    let email = control.value;
    

    if (!email)
      return null;

    return this.formDataService.getEmailValidationFromServer(email)
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
