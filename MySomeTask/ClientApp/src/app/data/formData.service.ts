import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FormData, Country } from './formData.model';
import { Observable, timer } from 'rxjs';
import { map, switchMap } from 'rxjs/operators';


@Injectable()
export class FormDataService {

  private formData: FormData = new FormData();
  private baseUrl: string;

  constructor(private http: HttpClient,
    @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;

  }

  getFormData(): FormData {
    return this.formData;
  }
    
  async getCountries() {

    let apiURL = `${this.baseUrl}Location/countries`;
    return await this.http
      .get<Country[]>(apiURL)
      .toPromise();
  }

  async getProvinciesByCountry(code: string) {

    let apiURL = `${this.baseUrl}Location/provincies/${code}`;
    return await this.http
      .get<string[]>(apiURL)
      .toPromise();
  }


  getEmailValidationFromServer(email: string) {
    let apiURL = `${this.baseUrl}RegisterUser/emailvalidate?email=${email}`;
    
    return this.http
      .get<any>(apiURL);
  }

  getPasswordValidationFromServer(password: string) {
    let apiURL = `${this.baseUrl}RegisterUser/passwordvalidate?password=${password}`;

    return this.http
      .get<any>(apiURL);
  }

  save(data: FormData) {
    let apiURL = `${this.baseUrl}RegisterUser/create`;

    return this.http
      .post<any>(apiURL,
        {
          email: data.email,
          password: data.password,
          country: data.country.name,
          province: data.province
        });
  }

}
