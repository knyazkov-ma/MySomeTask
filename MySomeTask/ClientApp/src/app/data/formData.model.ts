export class FormData {
    email: string = '';
    password: string = '';
    passwordConfirm: string = '';
    agree: boolean = false;
    country: string = '';
    province: string = '';

    clear() {
        this.email = '';
        this.password = '';
        this.passwordConfirm = '';
        this.agree = false;
        this.country = '';
        this.province = '';
    }
}

export class General {
    email: string = '';
    password: string = '';
}

export class Location {
    country: string = '';
    province: string = '';
}

export class Country {
    constructor(
        public code: string,
        public name: string
    ) { }
}
