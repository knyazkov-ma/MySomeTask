import { Component, OnInit } from '@angular/core';
import { FormData, General, Location, Country } from '../data/formData.model';
import { FormDataService } from '../data/formData.service';


@Component({
  selector: 'app-register-user',
  templateUrl: './register-user.component.html'
})

export class RegisterUserComponent implements OnInit {

  countries: Country[];
  provincies: string[];

  formData: FormData;
  isValidStep1: boolean;
  validateStep1: boolean;

  constructor(private formDataService: FormDataService) {
   
  }

  

  ngOnInit() {
    this.isValidStep1 = true;
    this.validateStep1 = false;

    this.formData = this.formDataService.getFormData();

    /*this.formDataService.getCountries();
    this.formDataService.getProvinciesByCountry(this.countries[0].code);*/

    console.log('General feature loaded!');
  }

  goToStep2() {
    alert();
    this.validateStep1 = true;
    this.isValidStep1 = false;
  }
  
}
