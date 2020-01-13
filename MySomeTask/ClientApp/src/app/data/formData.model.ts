export class FormData {
    email: string = '';
    password: string = '';    
    country: Country = null;
    province: string = '';
}

export class Country {
  code: string;
  name: string;    
}
