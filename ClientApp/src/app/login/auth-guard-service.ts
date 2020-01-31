import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { LoginServiceService } from './login-service.service';


@Injectable({
  providedIn: 'root'
})
export class AuthGuardServiceGuard {
  constructor(private authService: LoginServiceService, private router: Router) { }
  canActivate() {
    if (this.authService.isLoggedIn()) {
      return true;
    } else {
      this.router.navigate(['/']);
      return false;
    }
  }
}