import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { SignOnPageComponent } from './sign-on-page/sign-on-page.component';
import { ObjectsComponent } from './objects/objects.component';
import { RoomsComponent } from './rooms/rooms.component';

const routes: Routes = [
  {
    path: "signon", component: SignOnPageComponent, outlet: "main"
  },
  {
    path: "objects", component: ObjectsComponent, outlet: "main"
  },
  {
    path: "rooms", component: RoomsComponent, outlet: "main"
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
