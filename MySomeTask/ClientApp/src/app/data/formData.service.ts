import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FormData, General, Location, Country } from './formData.model';



@Injectable()
export class FormDataService {

  private formData: FormData = new FormData();
  private isGeneralFormValid: boolean = false;
  private isLocationFormValid: boolean = false;
  private baseUrl: string;

  constructor(private http: HttpClient,
    @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
  }

  getGeneral(): General {
    // Return the General data
    var general: General = {
      email: this.formData.email,
      password: this.formData.password      
    };
    return general;
  }

  setGeneral(data: General) {
    // Update the General data only when the General Form had been validated successfully
    this.isGeneralFormValid = true;
    this.formData.email = data.email;
    this.formData.password = data.password;
    // Validate General Step in Workflow
    
  }  

  getLocation(): Location {
    // Return the Location data
    var location: Location = {
      country: this.formData.country,
      province: this.formData.province
    };
    return location;
  }

  setLocation(data: Location) {
    // Update the Location data only when the Location Form had been validated successfully
    this.isLocationFormValid = true;
    this.formData.country = data.country;
    this.formData.province = data.province;
   
    
  }

  getFormData(): FormData {
    // Return the entire Form Data
    return this.formData;
  }

  resetFormData(): FormData {
    // Reset the workflow
    // Return the form data after all this.* members had been reset
    this.formData.clear();
    this.isGeneralFormValid = this.isLocationFormValid = false;
    return this.formData;
  }

  isFormValid() {
    // Return true if all forms had been validated successfully; otherwise, return false
    return this.isGeneralFormValid &&
      this.isLocationFormValid;
  }

  getCountries(): Country[] {
    
    var countries: Country[];

    this.http.get<Country[]>(this.baseUrl + 'RegisterUser/countries').subscribe(result => {
      countries = result;
    }, error => console.error(error));

    return countries;
  }

  getProvinciesByCountry(code: string): string[] {
    var provincies: string[];

    this.http.get<string[]>(this.baseUrl + 'RegisterUser/provincies/' + code).subscribe(result => {
      provincies = result;
    }, error => console.error(error));

    return provincies;
  }
  
}
