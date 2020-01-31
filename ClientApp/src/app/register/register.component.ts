import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators, FormBuilder } from '@angular/forms';
import { Router } from '@angular/router';

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

    myForm: FormGroup;
    loginCtrl: FormControl;
    passwordCtrl: FormControl;

    constructor(
        private formBuilder: FormBuilder,
        private router: Router,
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

    ngOnInit() {
        this.loginCtrl = this.formBuilder.control('', Validators.required);
        this.passwordCtrl = this.formBuilder.control('', Validators.required);

        this.contactForm = this.formBuilder.group({
            login: this.loginCtrl,
            password: this.passwordCtrl
        });
    }
    routeToDashboard() {
        this.router.navigate(['dashboard']);
    }
}
