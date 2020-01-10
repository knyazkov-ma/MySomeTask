import { Component, OnInit, Input } from '@angular/core';
import { General } from '../data/formData.model';
import { FormDataService } from '../data/formData.service';


@Component({
  selector: 'app-register-user',
  templateUrl: './register-user.component.html'
})

export class RegisterUserComponent implements OnInit {

  title: "asdasd";
  general: General;

  constructor(private formDataService: FormDataService) {
  }

  ngOnInit() {
    this.general = this.formDataService.getGeneral();
    console.log('General feature loaded!');
  }
  
}
