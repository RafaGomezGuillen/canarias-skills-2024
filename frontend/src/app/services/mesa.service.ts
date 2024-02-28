import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../environments/environment.development';
import { MesaModule } from '../modules/mesa/mesa.module';
@Injectable({
  providedIn: 'root'
})
export class MesaService {
  url: string = `${environment.baseApiUrl}/Mesa`;
  mesaList: MesaModule[] = [];
  mesa: MesaModule = new MesaModule();
  formData: MesaModule = new MesaModule();

  constructor(private http: HttpClient) {}

  get() {
    this.http.get(this.url).subscribe({
      next: (response) => {
        this.mesaList = response as MesaModule[];
      },
      error(err) {
        console.error(err);
      },
    });
  }

  getMesa(id: string) {
    this.http.get(`${this.url}/${id}`).subscribe({
      next: (response) => {
        this.mesa = response as MesaModule;
      },
    });
  }
}
