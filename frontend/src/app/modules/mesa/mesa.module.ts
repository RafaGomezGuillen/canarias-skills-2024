import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SalaModule } from '../sala/sala.module';
import { ComensalModule } from '../comensal/comensal.module';
@NgModule({
  declarations: [],
  imports: [CommonModule],
})
export class MesaModule {
  id: number = 0;
  numeroMesa: number = 0;
  capacidad: number = 0;
  idSala: number = 0;
  sala: SalaModule = new SalaModule();
  comensales: ComensalModule[] = [];
}
