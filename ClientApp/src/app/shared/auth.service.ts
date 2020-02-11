import { Injectable } from '@angular/core';
import { LoginServiceService } from '../login/login-service.service';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(

  ) { }

  public isAuthenticated(): boolean {
    console.log(JSON.parse(localStorage.getItem('user')) );
    return JSON.parse(localStorage.getItem('user'));
  }

}