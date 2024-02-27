import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

import { UserService } from '../../../services/user.service';

@Component({
  selector: 'app-user-admin',
  templateUrl: './user-admin.component.html',
  styles: ``
})
export class UserAdminComponent implements OnInit {
  constructor(
    private activatedRoute: ActivatedRoute,
    public userService: UserService,
  ) {}

  ngOnInit(): void {
    this.activatedRoute.params.subscribe((params) => {
      const username = params['username'];
      this.userService.getUser(username);
    });
  }
}
