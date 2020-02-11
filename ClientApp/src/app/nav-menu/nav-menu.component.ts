import { Component } from '@angular/core';
import { LoginServiceService} from '../login/login-service.service';
@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent {
  isExpanded = false;
  constructor(private auth: LoginServiceService) {}
  collapse() {
    this.isExpanded = false;
  }
  isLoggedIn() {
  }
  toggle() {
    this.isExpanded = !this.isExpanded;
  }
}
