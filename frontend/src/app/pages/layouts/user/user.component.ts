import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

import { UserService } from '../../../services/user.service';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styles: ``,
})
export class UserComponent implements OnInit {
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
