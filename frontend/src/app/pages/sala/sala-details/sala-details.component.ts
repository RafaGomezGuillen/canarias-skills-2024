import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

import { SalaService } from '../../../services/sala.service';
import { AuthService } from '../../../services/auth.service';
import { ComensalService } from '../../../services/comensal.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-sala-details',
  templateUrl: './sala-details.component.html',
  styles: ``,
})
export class SalaDetailsComponent {
  constructor(
    private activatedRoute: ActivatedRoute,
    public salaService: SalaService,
    public authService: AuthService,
    private comensalService: ComensalService,
    private toastr: ToastrService
  ) {}

  ngOnInit(): void {
    this.activatedRoute.params.subscribe((params) => {
      const id = params['id'];
      this.salaService.getSala(id);
    });
  }

  onDelete(id: number) {
    this.comensalService.delete(id).subscribe();
    this.toastr
      .success('El comensal ha sido eliminado correctamente')
      .onHidden.subscribe(() => {
        window.location.reload();
      });
  }
}
