import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { SignOnPageComponent } from './sign-on-page/sign-on-page.component';
import { ObjectsComponent } from './objects/objects.component';
import { RoomsComponent } from './rooms/rooms.component';
import { NotFoundComponent } from './not-found/not-found.component';

const routes: Routes = [
  {
    path: "signon", component: SignOnPageComponent, pathMatch: 'full'
  },
  {
    path: "objects", component: ObjectsComponent, pathMatch: 'full'
  },
  {
    path: "rooms", component: RoomsComponent, pathMatch: 'full'
  },
  {
    path: "", component: SignOnPageComponent, pathMatch: 'full'
  },
  {
    path: "**", component: NotFoundComponent, pathMatch: 'full'
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
