import { LoginServiceService } from './login-service.service';
import { NgForm } from '@angular/forms';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { FormsModule, ReactiveFormsModule } from '@angular/forms'
import { HttpClient, HttpRequest } from '@angular/common/http';
import { map } from "rxjs/operators";

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  submitted = false;

  firstSubmit = false;
  constructor(
    private loginService: LoginServiceService,
    private router: Router,
    private http: HttpClient
  ) {}

  ngOnInit() {
  }
  formOnSumbit(form: NgForm) {
    this.firstSubmit = true;
    if (form.valid) {
      this.loginService.authenticate(form.value, (success) => {
        if (success) {
          this.router.navigate(['admin']);
        }
      });
    }
  }

}
