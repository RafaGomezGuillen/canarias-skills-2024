import { Component } from '@angular/core';
import { AuthService } from '../../services/auth.service';
import { UserService } from '../../services/user.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
})
export class HeaderComponent {
  navigation = [
    {
      title: 'Upload image',
      path: '/image/upload-image',
      label: 'Go to Upload image page',
    },
    { title: 'Careers', path: '', label: 'Go to Careers page' },
    { title: 'Guides', path: '', label: 'Go to Guides page' },
    { title: 'Partners', path: '', label: 'Go to Partners page' },
  ];

  navigationDropdown = [
    { title: 'Dashboard', path: '', label: 'Go to Dashboard page' },
    { title: 'Settings', path: '', label: 'Go to settings page' },
    { title: 'Log out', path: '', label: 'Log out of the page' },
  ];

  constructor(
    public authService: AuthService,
    public userService: UserService
  ) {}

  onLogout() {
    this.authService.signOut();
  }
}
