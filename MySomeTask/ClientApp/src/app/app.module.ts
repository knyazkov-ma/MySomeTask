import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { RegisterUserComponent } from './register-user/register-user.component';
import { ArchwizardModule } from '../../node_modules/ng2-archwizard';

import { FormDataService } from './data/formData.service';

@NgModule({
  declarations: [
    AppComponent,
    RegisterUserComponent    
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ArchwizardModule,
    RouterModule.forRoot([
      { path: '', component: RegisterUserComponent, pathMatch: 'full' },
    ])
  ],
  providers: [
    { provide: FormDataService, useClass: FormDataService }],
  bootstrap: [AppComponent]
})
export class AppModule { }
