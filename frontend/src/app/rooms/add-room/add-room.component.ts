import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-add-room',
  templateUrl: './add-room.component.html',
  styleUrls: ['./add-room.component.scss']
})
export class AddRoomComponent {
  addRoomForm = new FormGroup({
    nameField: new FormControl('', [Validators.email, Validators.required]),
    descField: new FormControl('', [Validators.minLength(6), Validators.required])
  })

  onSubmit() {
    console.table(this.addRoomForm.value)
  }
}
