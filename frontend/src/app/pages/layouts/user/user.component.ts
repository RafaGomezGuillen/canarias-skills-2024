import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { HttpErrorResponse } from '@angular/common/http';

import { UserService } from '../../../services/user.service';
import { AuthService } from '../../../services/auth.service';
import { ReservaService } from '../../../services/reserva.service';
import { ToastrService } from 'ngx-toastr';
import { ReservaModule } from '../../../modules/reserva/reserva.module';
import { ComensalService } from '../../../services/comensal.service';
import { MesaService } from '../../../services/mesa.service';

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
    private reservaService: ReservaService,
    public comensalService: ComensalService,
    public mesaService: MesaService
  ) {}

  ngOnInit(): void {
    this.activatedRoute.params.subscribe((params) => {
      const username = params['username'];
      this.username = username;
      this.userService.getUser(username);
    });

    this.mesaService.get();
  }

  onSubmit() {
    this.comensalService.post().subscribe({
      next: (response) => {
        console.log(response);
        this.toastr
          .success('El comensal ha sido subido correctamente')
          .onHidden.subscribe(() => {
            window.location.reload();
          });
      },
      error: (err: HttpErrorResponse) => {
        // this.toastr.error(err.error.errors.Nombre);
        this.toastr.error(err.error);
        console.error(err);
      },
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
