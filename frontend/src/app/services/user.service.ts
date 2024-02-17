import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { environment } from '../environments/environment.development';
import { AuthService } from './auth.service';
import { UserModule } from '../modules/user/user.module';

@Injectable({
  providedIn: 'root',
})
export class UserService {
  url: string = `${environment.baseApiUrl}/User`;
  userList: UserModule[] = [];
  user: UserModule = new UserModule();

  constructor(private http: HttpClient, private authService: AuthService) {
  }

  get() {
    this.http.get(this.url).subscribe({
      next: (response) => {
        this.userList = response as UserModule[];
      },
      error(err) {
        console.error(err);
      },
    });
  }

  getUser(username: string) {
    this.http.get(`${this.url}/${username}`).subscribe({
      next: (response) => {
        this.user = response as UserModule;
      },
      error(err) {
        console.error(err);
      },
    });
  }

  isLoggedIn(): boolean {
    return !!localStorage.getItem('token');
  }

  isAdmin(): boolean {
    return this.authService.getRoleFromToken() === 'Admin';
  }
}
