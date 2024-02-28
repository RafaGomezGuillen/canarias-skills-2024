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
      title: 'Realizar una reserva',
      path: `/profile/${this.authService.getUsernameFromToken()}`,
      label: 'Realizar una reserva',
    },
    {
      title: 'Ver lista de salas',
      path: '/salas',
      label: 'Ver lista de salas',
    },
    {
      title: 'Ver lista de eventos',
      path: '/eventos',
      label: 'Ver lista de eventos por realizar',
    },
  ];

  navigationDropdown = [
    { title: 'Cerrar sesión', path: '', label: 'Cerrar sesión' },
  ];

  constructor(
    public authService: AuthService,
    public userService: UserService
  ) {}

  onLogout() {
    this.authService.signOut();
  }
}
