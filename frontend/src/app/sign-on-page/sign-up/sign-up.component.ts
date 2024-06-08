import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-sign-up',
  templateUrl: './sign-up.component.html',
  styleUrls: ['./sign-up.component.scss']
})
export class SignUpComponent {
  signUpForm = new FormGroup({
    firstNameField: new FormControl('', [Validators.minLength(2), Validators.maxLength(30), Validators.required]),
    lastNameField: new FormControl('', [Validators.minLength(2), Validators.maxLength(30)]),
    emailField: new FormControl('', [Validators.email, Validators.required]),
    passwordField: new FormControl('', [Validators.required]),
    cpasswordField: new FormControl('', [Validators.required])
  })
}
