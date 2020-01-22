import { LoginServiceService } from './login-service.service';
import { FormsModule, NgForm } from '@angular/forms';
import { LoginForm } from './login-form';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  firstSubmit = false;
  constructor(private loginService: LoginServiceService, private router: Router) { }

  ngOnInit() {
  }

  formOnSumbit(form: NgForm) {
    this.firstSubmit = true;
    if (form.valid) {
      this.loginService.authenticate(form.value, (success) => {
        if (success) {
          this.router.navigate(['dashboard']);
        }
      });
    }
  }

}
