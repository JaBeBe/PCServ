import { Injectable } from '@angular/core';
import { AuthService } from './auth.service';
import { Router, ActivatedRouteSnapshot } from '@angular/router';
import * as jwt_decode from "jwt-decode";

@Injectable({
  providedIn: 'root'
})
export class AuthRoleGuardService {

  tokenRole: string;
  expectedRole: any;

  constructor(public auth: AuthService, public router: Router) { }
  canActivate(): boolean {

    this.expectedRole = "Administrator";

    this.tokenRole = localStorage.getItem('user');
    const decodedRole = jwt_decode(this.tokenRole);
 
    if (
      !this.auth.isAuthenticated() ||
      decodedRole.role !== this.expectedRole
    ) {
      this.router.navigate(['/admin']);
      return false;
    }

    return true;
  }
}
