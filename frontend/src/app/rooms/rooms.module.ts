import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RoomsComponent } from './rooms.component';
import { AddRoomComponent } from './add-room/add-room.component';
import { ReactiveFormsModule } from '@angular/forms';



@NgModule({
  declarations: [
    RoomsComponent,
    AddRoomComponent
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule
  ],
  exports: [
    RoomsComponent
  ]
})
export class RoomsModule { }
