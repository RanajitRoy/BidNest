import { Component } from '@angular/core';
import { AbstractControl, FormControl, FormGroup, ValidationErrors, ValidatorFn, Validators } from '@angular/forms';

function checkPasswordValidator() : ValidatorFn { 
  return (group: AbstractControl):  ValidationErrors | null => { 
    let pass = group.get('passwordField')?.value;
    let confirmPass = group.get('cpasswordField')?.value   
    return pass === confirmPass ? null : { checkPassword: true }
  }
}

@Component({
  selector: 'app-sign-up',
  templateUrl: './sign-up.component.html',
  styleUrls: ['./sign-up.component.scss']
})
export class SignUpComponent {
  

  signUpForm = new FormGroup({
      firstNameField: new FormControl('', [Validators.maxLength(30), Validators.required]),
      lastNameField: new FormControl('', [Validators.maxLength(30)]),
      emailField: new FormControl('', [Validators.email, Validators.required]),
      passwordField: new FormControl('', [Validators.minLength(6), Validators.required]),
      cpasswordField: new FormControl('', [Validators.required]),
    },
    { validators: [checkPasswordValidator()] }
  )
}
