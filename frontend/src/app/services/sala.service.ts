import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../environments/environment.development';
import { SalaModule } from '../modules/sala/sala.module';

@Injectable({
  providedIn: 'root'
})
export class SalaService {
  url: string = `${environment.baseApiUrl}/Sala`;
  salaList: SalaModule[] = [];
  sala: SalaModule = new SalaModule();
  formData: SalaModule = new SalaModule();

  constructor(private http: HttpClient) {}

  get() {
    this.http.get(this.url).subscribe({
      next: (response) => {
        this.salaList = response as SalaModule[];
      },
      error(err) {
        console.error(err);
      },
    });
  }

  getSala(id: string) {
    this.http.get(`${this.url}/${id}`).subscribe({
      next: (response) => {
        this.sala = response as SalaModule;
      },
    });
  }
}
