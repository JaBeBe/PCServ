import { LoginServiceService } from './login-service.service';
import { NgForm } from '@angular/forms';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { DataSharingService } from '../shared/data-sharing.service'

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  submitted = false;
  firstSubmit = false;
  tokenRole: any;
  showAlert: boolean;

  constructor(
    private loginService: LoginServiceService,
    private router: Router,
    private dataSharingService: DataSharingService
  ) { }
  ngOnInit() {
    this.showAlert = false;
  }
  refresh() {

  }

  closeAlert() {
    this.showAlert = false;
  }
  formOnSumbit(form: NgForm) {
    this.firstSubmit = true;
    if (form.valid) {
      this.loginService.authenticate(form.value, (success) => {
        if (success) {
          this.dataSharingService.isAuthenticated.next(true);

          this.router.navigate(['/dashboard']);
        } else {
          this.showAlert = true;
        }
      });
    }
  }



}
