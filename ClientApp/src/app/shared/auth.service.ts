import { Injectable } from '@angular/core';
import { LoginServiceService } from '../login/login-service.service';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(

  ) { }

  public isAuthenticated(): boolean {
    const token = localStorage.getItem('user');
    if(token) return true
  }

}