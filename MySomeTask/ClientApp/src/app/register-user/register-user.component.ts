import { Component, OnInit } from '@angular/core';
import { FormData, General, Location, Country } from '../data/formData.model';
import { FormDataService } from '../data/formData.service';


@Component({
  selector: 'app-register-user',
  templateUrl: './register-user.component.html'
})

export class RegisterUserComponent implements OnInit {


  formData: FormData;
  isValidStep1: boolean;
  validateStep1: boolean;
  selectedCountry: Country;
  selectedProvince: string;

  constructor(private formDataService: FormDataService) {
    this.selectedCountry = null;
    this.selectedProvince = null;
  }



  ngOnInit() {
    this.isValidStep1 = true;
    this.validateStep1 = false;

    this.formData = this.formDataService.getFormData();

    this.formDataService.getCountries()
      .then(_ => {
        this.selectedCountry = this.formDataService.countries[0];
        this.formDataService.getProvinciesByCountry(this.formDataService.countries[0].code)
          .then(_ => {
            this.selectedProvince = this.formDataService.provincies[0];
          });
      });


    console.log('General feature loaded!');
  }

  goToStep2() {
    alert();
    this.validateStep1 = true;
    this.isValidStep1 = false;
  }

  countryChange(value) {
    this.selectedCountry = value;
    this.formDataService.getProvinciesByCountry(value.code)
      .then(_ => {
        this.selectedProvince = this.formDataService.provincies[0];
      });
  }

  provinceChange(value) {
    this.selectedProvince = value;    
  }
}
