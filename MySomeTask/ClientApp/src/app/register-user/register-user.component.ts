import { Component, OnInit } from '@angular/core';
import { FormData, General, Location, Country } from '../data/formData.model';
import { FormDataService } from '../data/formData.service';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';



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
  form: FormGroup;
  
  provincies: string[] = [];
  countries: Country[] = [];

  constructor(private formDataService: FormDataService,
    private fb: FormBuilder) {
    this.selectedCountry = null;
    this.selectedProvince = null;    
  }



  async ngOnInit() {
    

    this.isValidStep1 = true;
    this.validateStep1 = false;

    this.formData = this.formDataService.getFormData();

    this.countries = await this.formDataService.getCountries();
    this.selectedCountry = this.countries[0];
    this.provincies = await this.formDataService.getProvinciesByCountry(this.countries[0].code);
    this.selectedProvince = this.provincies[0];

    
    console.log('General feature loaded!');
  }

  goToStep2() {
    alert();
    this.validateStep1 = true;
    this.isValidStep1 = false;
  }

  async countryChange(value) {
    this.selectedCountry = value;
    this.provincies = await this.formDataService.getProvinciesByCountry(value.code);
    this.selectedProvince = this.provincies[0];
  }

  provinceChange(value) {
    this.selectedProvince = value;    
  }
  
}
