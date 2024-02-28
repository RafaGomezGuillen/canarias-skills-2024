import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../environments/environment.development';
import { ComensalModule } from '../modules/comensal/comensal.module';

@Injectable({
  providedIn: 'root',
})
export class ComensalService {
  url: string = `${environment.baseApiUrl}/Comensal`;
  comensalList: ComensalModule[] = [];
  comensal: ComensalModule = new ComensalModule();
  formData: ComensalModule = new ComensalModule();

  constructor(private http: HttpClient) {}

  get() {
    this.http.get(this.url).subscribe({
      next: (response) => {
        this.comensalList = response as ComensalModule[];
      },
      error(err) {
        console.error(err);
      },
    });
  }

  getComensal(id: string) {
    this.http.get(`${this.url}/${id}`).subscribe({
      next: (response) => {
        this.comensal = response as ComensalModule;
      },
    });
  }

  post() {
    console.log(this.formData);
    return this.http.post(this.url, this.formData);
  }

  put() {
    return this.http.put(`${this.url}/${this.formData.id}`, this.formData);
  }

  delete(id: number) {
    return this.http.delete(`${this.url}/${id}`);
  }
}
