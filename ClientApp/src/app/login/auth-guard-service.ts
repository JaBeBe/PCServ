import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { LoginServiceService } from './login-service.service';
import { LoginForm } from './login-form';


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