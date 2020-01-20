import { LoginForm } from './login-form';
import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class LoginServiceService {

  private url = 'login';

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  authenticate(loginForm: LoginForm) {
    console.log(loginForm);
    return this.http.post<LoginForm>(this.baseUrl + this.url, loginForm).subscribe(result => {
      console.log(result);
    }, error => console.error(error));
  }
}
