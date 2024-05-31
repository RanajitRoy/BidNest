import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SignOnPageComponent } from './sign-on-page.component';
import { LoginComponent } from './login/login.component';
import { SignUpComponent } from './sign-up/sign-up.component';



@NgModule({
  declarations: [
    SignOnPageComponent,
    LoginComponent,
    SignUpComponent
  ],
  imports: [
    CommonModule
  ]
})
export class SignOnPageModule { }
