import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

import { UserService } from '../../../services/user.service';
import { AuthService } from '../../../services/auth.service';
import { ReservaService } from '../../../services/reserva.service';
import { ToastrService } from 'ngx-toastr';
import { ReservaModule } from '../../../modules/reserva/reserva.module';

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
    public authService: AuthService,
    private toastr: ToastrService,
    private reservaService: ReservaService
  ) {}

  ngOnInit(): void {
    this.activatedRoute.params.subscribe((params) => {
      const username = params['username'];
      this.username = username;
      this.userService.getUser(username);
    });
  }

  populateForm(reserva: ReservaModule) {
    this.reservaService.formData = Object.assign({}, reserva);
  }

  onDelete(id: number) {
    this.reservaService.delete(id).subscribe();
    this.toastr
      .success('La reserva se ha eliminado correctamente')
      .onHidden.subscribe(() => {
        window.location.reload();
      });
  }
}
