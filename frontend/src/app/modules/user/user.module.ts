import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReservaModule } from '../reserva/reserva.module';

@NgModule({
  declarations: [],
  imports: [CommonModule],
})
export class UserModule {
  username: string = '';
  email: string = '';
  roles: string[] = [];
  reservas: ReservaModule[] = [];
}