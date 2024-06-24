import { Component } from '@angular/core';
import { Room } from 'src/shared/types';

@Component({
  selector: 'app-rooms',
  templateUrl: './rooms.component.html',
  styleUrls: ['./rooms.component.scss']
})
export class RoomsComponent {
  roomList: Room[] = [
    {
      id: '1',
      name: 'room1',
      description: "room 1 desc",
      numOfObjects: 2,
      numOfUsers: 3,
      owner: '1'
    },
    {
      id: '2',
      name: 'room2',
      description: "room 2 desc",
      numOfObjects: 1,
      numOfUsers: 2,
      owner: '2'
    },
    {
      id: '3',
      name: 'room3',
      description: "room 3 desc",
      numOfObjects: 1,
      numOfUsers: 3,
      owner: '3'
    }
  ]

}
