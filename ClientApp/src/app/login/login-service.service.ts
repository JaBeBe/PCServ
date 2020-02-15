import { LoginForm } from './login-form';
import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { User } from '../user/user';
import { Observable } from 'rxjs';
import { resolve } from 'url';
import * as jwt_decode from "jwt-decode";

@Injectable({
  providedIn: 'root'
})
export class LoginServiceService {

  private url = 'login';
  token: string;
  tokenRole: string;

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  authenticate(loginForm: LoginForm, callback: (n: boolean) => any) {
    this.http.post<User>(this.baseUrl + this.url, loginForm).subscribe(result => {
      callback(true);
      this.storeUserData(result);
    }, error => {
      console.error(error);
      callback(false);
    });
  }
  storeUserData(user: User): void {
    localStorage.setItem('user', JSON.stringify(user.token));

    this.token = localStorage.getItem('user');
    const decoded = jwt_decode(this.token);
    console.log("Decoted role: " + JSON.stringify(decoded.role));

  }


  getUserData(): User {
    return JSON.parse(localStorage.getItem('user'));
  }

}
