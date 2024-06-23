import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ObjectsComponent } from './objects.component';
import { ObjectViewerComponent } from './object-viewer/object-viewer.component';



@NgModule({
  declarations: [
    ObjectsComponent,
    ObjectViewerComponent
  ],
  imports: [
    CommonModule
  ],
  exports: [
    ObjectsComponent
  ]
})
export class ObjectsModule { }
