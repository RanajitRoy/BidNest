import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RoomsComponent } from './rooms.component';
import { AddRoomComponent } from './add-room/add-room.component';



@NgModule({
  declarations: [
    RoomsComponent,
    AddRoomComponent
  ],
  imports: [
    CommonModule
  ],
  exports: [
    RoomsComponent
  ]
})
export class RoomsModule { }
