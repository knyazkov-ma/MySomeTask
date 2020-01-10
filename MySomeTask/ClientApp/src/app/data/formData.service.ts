import { Injectable } from '@angular/core';

import { FormData, General, Location } from './formData.model';
import { WorkflowService } from '../workflow/workflow.service';
import { STEPS } from '../workflow/workflow.model';

@Injectable()
export class FormDataService {

  private formData: FormData = new FormData();
  private isGeneralFormValid: boolean = false;
  private isLocationFormValid: boolean = false;

  constructor(private workflowService: WorkflowService) {
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
    this.workflowService.validateStep(STEPS.general);
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
    // Validate Location Step in Workflow
    this.workflowService.validateStep(STEPS.location);
  }

  getFormData(): FormData {
    // Return the entire Form Data
    return this.formData;
  }

  resetFormData(): FormData {
    // Reset the workflow
    this.workflowService.resetSteps();
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
}
