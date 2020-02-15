import { Injectable, Output, EventEmitter } from '@angular/core';
import { LoginServiceService } from '../login/login-service.service';
import { JwtHelperService } from "@auth0/angular-jwt";
import { User } from '../user/user';
import * as jwtDecode from "jwt-decode";
import { BehaviorSubject, Observable, Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  @Output() getLoggedInName: EventEmitter<any> = new EventEmitter();

  token: string;
  constructor(

  ) { }

  public isAuthenticated(){
    this.token = localStorage.getItem('user');
    const decoded = jwtDecode(this.token);

    let o = new Date(Date.now() * 1000);
    let d = new Date(decoded.exp * 1000);
    if (o >= d) {
      
      return true;
    } else {
      return false;
    }
  }
}