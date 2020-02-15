import { Component, OnInit } from '@angular/core';
import { AuthService } from '../shared/auth.service';
import { Observable } from 'rxjs';
import { Router, NavigationEnd } from '@angular/router';
import { DataSharingService } from '../shared/data-sharing.service';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent implements OnInit {
  isAuthenticated: boolean;
  isExpanded: boolean = false;
  userName: string;
  mySubscription: any;

  constructor(
    private authService: AuthService,
    private dataSharingService: DataSharingService
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
    this.dataSharingService.isAuthenticated.next(false);

  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }
  ngOnInit() {
    this.isAuthenticated = this.authService.isAuthenticated();

  }
}
