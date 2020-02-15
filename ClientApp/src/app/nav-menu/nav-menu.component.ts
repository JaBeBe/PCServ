import { Component, OnInit } from '@angular/core';
import { AuthService } from '../shared/auth.service';
import { Observable } from 'rxjs';
import { Router, NavigationEnd } from '@angular/router';
import { DataSharingService } from '../shared/data-sharing.service';
import {AuthRoleGuardService} from '../shared/auth-role-guard.service';
@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent implements OnInit {
  isAuthenticated: boolean;
  isAdmin: boolean;

  isExpanded: boolean = false;
  userName: string;
  mySubscription: any;

  constructor(
    private authService: AuthService,
    private dataSharingService: DataSharingService,
    private authRole: AuthRoleGuardService
  ) {
    this.dataSharingService.isAuthenticated.subscribe(value => {
      this.isAuthenticated = value;
    });
  }

  collapse() {
    this.isExpanded = false;
  }
  logout() {
    localStorage.removeItem('user');
    localStorage.removeItem('role');

    this.dataSharingService.isAuthenticated.next(false);

  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }
  ngOnInit() {
    this.isAuthenticated = this.authService.isAuthenticated();
    this.isAdmin = this.authRole.canActivate();

  }
}
