import { Component } from '@angular/core';
import { ReservaService } from '../../../services/reserva.service';
@Component({
  selector: 'app-reserva-list',
  templateUrl: './reserva-list.component.html',
  styles: ``,
})
export class ReservaListComponent {
  constructor(public reservaService: ReservaService) {
    this.reservaService.get();
  }
}
