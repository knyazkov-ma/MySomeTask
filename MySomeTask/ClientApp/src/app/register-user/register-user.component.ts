import { Component, OnInit, Input } from '@angular/core';
import { Router } from '@angular/router';
import { General } from '../data/formData.model';
import { FormDataService } from '../data/formData.service';
import { WorkflowService } from '../workflow/workflow.service';

@Component({
  selector: 'app-home',
  templateUrl: './register-user.component.html',
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
