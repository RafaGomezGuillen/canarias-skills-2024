import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MesaModule } from '../mesa/mesa.module';

@NgModule({
  declarations: [],
  imports: [CommonModule],
})
export class ComensalModule {
  id: number = 0;
  nombre: string = '';
  idMesa: number = 0;
  mesa: MesaModule = new MesaModule();
}
