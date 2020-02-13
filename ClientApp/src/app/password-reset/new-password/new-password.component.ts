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
  private userId: number;
  private resetToken: string;
  constructor(private route: ActivatedRoute, private passwordService: PasswordServiceService, private router: Router) { }

  ngOnInit() {
    this.firstSubmit = false;
    this.route.queryParams.subscribe(params => {
      this.userId = +params.userId;
      this.resetToken = params.resetToken;
    });
  }

  formOnSumbit(form: NgForm) {
    this.firstSubmit = true;
    if (form.valid) {
      this.passwordService.setNewPassword(form.value, this.userId, this.resetToken, (success) => {
        if (success) {
          this.router.navigate(['']);
        }
      });
    }
  }
}
