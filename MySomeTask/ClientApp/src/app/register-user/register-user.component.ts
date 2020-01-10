import { Component, OnInit, Input } from '@angular/core';
import { FormData, General, Location } from '../data/formData.model';
import { FormDataService } from '../data/formData.service';


@Component({
  selector: 'app-register-user',
  templateUrl: './register-user.component.html'
})

export class RegisterUserComponent implements OnInit {

  countries: string[];
  provincies: string[];

  formData: FormData;
  isValidStep1: boolean;
  validateStep1: boolean;

  constructor(private formDataService: FormDataService) {
  }

  ngOnInit() {
    this.isValidStep1 = false;
    this.validateStep1 = false;

    this.formData = this.formDataService.getFormData();

    this.countries = this.formDataService.getCountries();
    this.provincies = this.formDataService.getProvinciesByCountry(this.countries[0]);

    console.log('General feature loaded!');
  }

  goToStep2() {
    alert();
    this.validateStep1 = true;
    this.isValidStep1 = false;
  }
  
}
