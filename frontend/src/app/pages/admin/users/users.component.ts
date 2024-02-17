import { Component } from '@angular/core';
import { UserService } from '../../../services/user.service';
import { AuthService } from '../../../services/auth.service';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
})
export class UsersComponent {
  constructor(public userService: UserService, public authService: AuthService) {}

  ngOnInit(): void {
    this.userService.get();
  }
}
