import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReservaModule } from '../reserva/reserva.module';

@NgModule({
  declarations: [],
  imports: [CommonModule],
})
export class SalaModule {
  id: number = 0;
  nombre: string = '';
  aforoMax: number = 0;
  aforoMin: number = 0;
  estaReservada: boolean = false;
  route: string = '';
  routeLocalhost: string = '';
  reserva: ReservaModule[] = [];
}
