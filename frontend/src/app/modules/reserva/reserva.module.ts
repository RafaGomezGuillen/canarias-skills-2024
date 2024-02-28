import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SalaModule } from '../sala/sala.module';

@NgModule({
  declarations: [],
  imports: [CommonModule],
})
export class ReservaModule {
  id: number = 0;
  nombre: string = '';
  invitados: number = 0;
  date: Date = new Date();
  username: string = '';
  idSala: number = 0;
  sala: SalaModule = new SalaModule();
}
