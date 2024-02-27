import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

import { UserService } from '../../../services/user.service';
import { AuthService } from '../../../services/auth.service';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styles: ``,
})
export class UserComponent implements OnInit {
  username: string = '';

  constructor(
    private activatedRoute: ActivatedRoute,
    public userService: UserService,
    public authService: AuthService
  ) {}

  ngOnInit(): void {
    this.activatedRoute.params.subscribe((params) => {
      const username = params['username'];
      this.username = username;
      this.userService.getUser(username);
    });
  }
}
