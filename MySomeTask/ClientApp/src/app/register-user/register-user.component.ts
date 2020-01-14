import { Component, OnInit, ViewChild } from '@angular/core';
import { FormData, Country } from '../data/formData.model';
import { FormDataService } from '../data/formData.service';


@Component({
  selector: 'app-register-user',
  templateUrl: './register-user.component.html'
})

export class RegisterUserComponent implements OnInit {

  error = null;
  formData: FormData;
    
      
  provincies: string[] = [];
  countries: Country[] = [];

  @ViewChild('email') email;
  @ViewChild('password') password;
  @ViewChild('confirmPassword') confirmPassword;
  @ViewChild('agree') agree;
  
  
  constructor(private formDataService: FormDataService) {
    
  }

  isValidStep1(): boolean {
    return this.email.valid
      && this.password.valid
      && this.confirmPassword.valid
      && this.agree.valid
  }  
    
  async ngOnInit() {
    
    console.log(this.email);
    
    this.formData = this.formDataService.getFormData();

    this.countries = await this.formDataService.getCountries();
    this.formData.country = this.countries[0];
    this.provincies = await this.formDataService.getProvinciesByCountry(this.countries[0].code);
    this.formData.province = this.provincies[0];
        
    console.log('General feature loaded!');
  }

  async countryChange(value) {
    this.provincies = await this.formDataService.getProvinciesByCountry(value.code);
    this.formData.province = this.provincies[0];
  }
    

  save() {
    this.formDataService.save(this.formData).subscribe(
      success => {
        this.error = null;
        alert('Register user success!')
      },
      error => {
        this.error = error.error;

        if (this.error && this.error.errorDetails) {
          if (this.error.errorDetails.Email) {
            this.email.control.setErrors({ 'domain': this.error.errorDetails.Email });
          }
          if (this.error.errorDetails.Password) {
            this.password.control.setErrors({ 'domain': this.error.errorDetails.Password });
          }          
        }

        console.log(error);
      });
  } 
  
}
