import { Component, OnInit, Inject } from '@angular/core';
import { FormControl, FormGroup, Validators, FormBuilder } from '@angular/forms';
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';

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
    emailCtrl: FormControl;
    firstNameCtrl: FormControl;
    lastNameCtrl: FormControl;
    passwordCtrl: FormControl;
    confirmPasswordCtrl: FormControl;

    constructor(
        private formBuilder: FormBuilder,
        private router: Router,
        private http: HttpClient,
        @Inject('BASE_URL') private baseUrl: string
    ) {
    }


    onSubmit(): void {
        this.submitted = true;
        if (this.contactForm.valid) {
          const url = 'register';
            this.http.post(this.baseUrl + url, this.contactForm.value).subscribe(result => {
              console.log(result);
              this.router.navigate(['']);
            }, error => {
              console.error(error);
              const message = error.error.message ? error.error.message : error.error.title;
            });
        }
    }

    ngOnInit() {
        this.loginCtrl = this.formBuilder.control('', Validators.required);
        this.passwordCtrl = this.formBuilder.control('', Validators.required);
        this.emailCtrl = this.formBuilder.control('', Validators.required);
        this.firstNameCtrl = this.formBuilder.control('', Validators.required);
        this.lastNameCtrl = this.formBuilder.control('', Validators.required);
        this.confirmPasswordCtrl = this.formBuilder.control('', Validators.required);

        this.contactForm = this.formBuilder.group({
            login: this.loginCtrl,
            password: this.passwordCtrl,
            confirmPassword: this.confirmPasswordCtrl,
            email: this.emailCtrl,
            firstName: this.firstNameCtrl,
            lastName: this.lastNameCtrl
        });
    }
}
