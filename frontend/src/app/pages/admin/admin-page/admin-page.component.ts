import { Component } from '@angular/core';
import { UserService } from '../../../services/user.service';

@Component({
  selector: 'app-admin-page',
  templateUrl: './admin-page.component.html',
})
export class AdminPageComponent {
  navigations = [
    {
      title: 'Users',
      desc: 'CRUD operations with users.',
      path: '/admin/users',
    },
    {
      title: 'Obras',
      desc: 'Operaciones CRUD con obras.',
      path: '/admin/obras',
    },
  ];

  constructor(public userService: UserService) {}
}
