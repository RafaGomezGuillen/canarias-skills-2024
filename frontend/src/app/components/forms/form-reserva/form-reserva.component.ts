import { Component, OnInit } from '@angular/core';
import { HttpErrorResponse } from '@angular/common/http';

import { ReservaService } from '../../../services/reserva.service';
import { ToastrService } from 'ngx-toastr';
import { SalaService } from '../../../services/sala.service';
import { AuthService } from '../../../services/auth.service';

@Component({
  selector: 'app-form-reserva',
  templateUrl: './form-reserva.component.html',
  styles: ``,
})
export class FormReservaComponent implements OnInit {
  constructor(
    public reservaService: ReservaService,
    private toastr: ToastrService,
    public authService: AuthService,
    public salaService: SalaService
  ) {}

  ngOnInit(): void {
    this.salaService.get();
  }

  onSubmit() {
    if (this.reservaService.formData.id === 0) {
      this.insertRecord();
    } else {
      this.updateRecord();
    }
  }

  insertRecord() {
    this.reservaService.formData.username =
      this.authService.getUsernameFromToken();

    this.reservaService.post().subscribe({
      next: (response) => {
        console.log(response);
        this.toastr
          .success('La reserva ha sido subida correctamente')
          .onHidden.subscribe(() => {
            window.location.reload();
          });
      },
      error: (err: HttpErrorResponse) => {
        this.toastr.error(err.error);
        console.error(err);
      },
    });
  }

  updateRecord() {
    this.reservaService.put().subscribe({
      next: (response) => {
        console.log(response);
        this.toastr
          .success('La reserva ha sido editada correctamente')
          .onHidden.subscribe(() => {
            window.location.reload();
          });
      },
      error: (err: HttpErrorResponse) => {
        this.toastr.error(err.error);
        console.error(err);
      },
    });
  }
}
