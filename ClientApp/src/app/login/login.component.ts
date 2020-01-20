import { LoginServiceService } from './login-service.service';
import { FormsModule, NgForm } from '@angular/forms';
import { LoginForm } from './login-form';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  firstSubmit = false;
  constructor(private loginService: LoginServiceService) { }

  ngOnInit() {
  }

  formOnSumbit(form: NgForm) {
    this.firstSubmit = true;
    if (form.valid) {
      this.loginService.authenticate(form.value);
    }
  }

}
