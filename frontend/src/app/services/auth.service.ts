import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';

// JWT
import { JwtHelperService } from '@auth0/angular-jwt';

import { environment } from '../environments/environment.development';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  url: string = `${environment.baseApiUrl}/Auth`;
  userPayload: any;

  constructor(private http: HttpClient, private router: Router) {
    this.userPayload = this.decodedToken();
  }

  login(user: any) {
    return this.http.post(`${this.url}/login`, user);
  }

  register(user: any) {
    return this.http.post(`${this.url}/register`, user);
  }

  storeToken(tokeValue: string) {
    localStorage.setItem('token', tokeValue);
  }

  getToken() {
    return localStorage.getItem('token');
  }

  signOut() {
    localStorage.clear();
    this.router.navigate(['login']);
  }

  decodedToken() {
    const jwtHelper = new JwtHelperService();
    const myToken = this.getToken()!;

    return jwtHelper.decodeToken(myToken);
  }

  getUsernameFromToken() {
    if (this.userPayload) {
      return this.userPayload[
        'http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name'
      ];
    }
  }

  getRoleFromToken() {
    if (this.userPayload) {
      return this.userPayload[
        'http://schemas.microsoft.com/ws/2008/06/identity/claims/role'
      ];
    }
  }
}
