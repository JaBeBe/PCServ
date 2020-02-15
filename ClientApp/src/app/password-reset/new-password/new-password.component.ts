import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, ActivatedRouteSnapshot, Router } from '@angular/router';
import { NgForm } from '@angular/forms';
import { PasswordServiceService } from '../password-service.service';

@Component({
  selector: 'app-new-password',
  templateUrl: './new-password.component.html',
  styleUrls: ['./new-password.component.css']
})
export class NewPasswordComponent implements OnInit {

  public firstSubmit: boolean;
  public alertMessage: string;
  public showAlert: boolean;
  private userId: number;
  private resetToken: string;
  constructor(private route: ActivatedRoute, private passwordService: PasswordServiceService, private router: Router) { }

  ngOnInit() {
    this.firstSubmit = false;
    this.route.queryParams.subscribe(params => {
      this.userId = +params.userId;
      this.resetToken = params.resetToken;
    });
    this.alertMessage = '';
    this.showAlert = false;
  }

  formOnSumbit(form: NgForm) {
    this.firstSubmit = true;
    if (form.valid) {
      this.passwordService.setNewPassword(form.value, this.userId, this.resetToken, (success, message) => {
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
