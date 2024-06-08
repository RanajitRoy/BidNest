import { Component } from '@angular/core';

@Component({
  selector: 'app-sign-on-page',
  templateUrl: './sign-on-page.component.html',
  styleUrls: ['./sign-on-page.component.scss']
})
export class SignOnPageComponent {
  activeForm : string = 'login';

  changeForm(event: any) {
    this.activeForm = event.target.value;
  }
}
