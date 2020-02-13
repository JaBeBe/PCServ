import { Router } from '@angular/router';
import { PasswordServiceService } from './../password-service.service';
import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-request-reset',
  templateUrl: './request-reset.component.html',
  styleUrls: ['./request-reset.component.css']
})
export class RequestResetComponent implements OnInit {

  public firstSubmit: boolean;
  public alertMessage: string;
  public showAlert: boolean;

  constructor(private passwordService: PasswordServiceService, private router: Router) {
    this.firstSubmit = false;
  }

  ngOnInit() {
    this.alertMessage = '';
    this.showAlert = false;
  }

  formOnSumbit(form: NgForm) {
    this.firstSubmit = true;
    if (form.valid) {
      this.passwordService.requestPasswordReset(form.value, (success, message) => {
        if (success) {
          this.router.navigate(['']);
        } else {
          this.showAlert = true;
          this.alertMessage = message;
        }
      });
    }
  }
  closeAlert() {
    this.alertMessage = '';
    this.showAlert = false;
  }

}
