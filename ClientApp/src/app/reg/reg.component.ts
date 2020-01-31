import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators, FormBuilder } from '@angular/forms';

@Component({
  selector: 'app-reg',
  templateUrl: './reg.component.html',
  styleUrls: ['./reg.component.css']
})
export class RegComponent implements OnInit {


  contactForm: FormGroup;
  contact = {
    login: '',
    password: ''
  };
  submitted = false;

  constructor(
    private formBuilder: FormBuilder,
  ) {
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

  ngOnInit() { }
}
