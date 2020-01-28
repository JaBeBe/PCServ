import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  
  contactForm: FormGroup;
  contact = {
      login: '',
      password: ''
  };
  submitted = false;

  constructor() {
      this.createForm();
  }

  createForm(): void {
      this.contactForm = new FormGroup({
          'login': new FormControl(this.contact.login, [
              Validators.required,
              Validators.minLength(1)
          ]),
          'password': new FormControl(this.contact.password, [
              Validators.required,
              Validators.minLength(1)
          ])
      });
  }

  onSubmit(): void {
      this.submitted = true;
  }


  ngOnInit() {
  }

}
