import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoginComponent } from './login/login.component';
import { SignUpComponent } from './sign-up/sign-up.component';
import { ReactiveFormsModule } from '@angular/forms';
import { SignOnPageComponent } from './sign-on-page.component';



@NgModule({
  declarations: [
    LoginComponent,
    SignUpComponent,
    SignOnPageComponent
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule
  ],
  exports: [
    SignOnPageComponent
  ]
})
export class SignOnPageModule { }
