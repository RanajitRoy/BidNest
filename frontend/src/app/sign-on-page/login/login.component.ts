import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent {

  loginForm = new FormGroup({
    emailField: new FormControl('', [Validators.email, Validators.required]),
    passwordField: new FormControl('', [Validators.minLength(6), Validators.required])
  })

  onSubmit() {
    console.table(this.loginForm.value)
  }
}
