import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../environments/environment.development';
import { ReservaModule } from '../modules/reserva/reserva.module';

@Injectable({
  providedIn: 'root'
})
export class ReservaService {
  url: string = `${environment.baseApiUrl}/Reserva`;
  reservaList: ReservaModule[] = [];
  reserva: ReservaModule = new ReservaModule();
  formData: ReservaModule = new ReservaModule();

  constructor(private http: HttpClient) {}

  get() {
    this.http.get(this.url).subscribe({
      next: (response) => {
        this.reservaList = response as ReservaModule[];
      },
      error(err) {
        console.error(err);
      },
    });
  }

  getRerseva(id: string) {
    this.http.get(`${this.url}/${id}`).subscribe({
      next: (response) => {
        this.reserva = response as ReservaModule;
      },
    });
  }

  post() {
    return this.http.post(this.url, this.formData);
  }

  put() {
    return this.http.put(`${this.url}/${this.formData.id}`, this.formData);
  }

  delete(id: number) {
    return this.http.delete(`${this.url}/${id}`);
  }
}
