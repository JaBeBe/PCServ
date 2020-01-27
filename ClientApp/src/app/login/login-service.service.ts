import { LoginForm } from './login-form';
import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { User } from '../user/user';
import { Observable } from 'rxjs';
import { resolve } from 'url';

@Injectable({
  providedIn: 'root'
})
export class LoginServiceService {

  private url = 'login';
  navItems: any;

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  authenticate(loginForm: LoginForm, callback: (n: boolean) => any) {
    this.http.post<User>(this.baseUrl + this.url, loginForm).subscribe(result => {
      console.log(result);
      callback(true);
      this.storeUserData(result);
    }, error => {
      console.error(error);
      callback(false);
    });
  }

  storeUserData(user: User): void {
    localStorage.setItem('user', JSON.stringify(user));
  }

  getUserData(): User {
    return JSON.parse(localStorage.getItem('user'));
  }

  // Only for unit test
  isLoggedIn() {
    return true;
  }

  getData(){
   return this.http.get("../assets/data.json")}
  
}
