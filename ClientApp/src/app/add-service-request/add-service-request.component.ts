import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-add-service-request',
  templateUrl: './add-service-request.component.html',
  styleUrls: ['./add-service-request.component.css']
})
export class AddServiceRequestComponent implements OnInit {

  firstSubmit = false;

  constructor( private router: Router ) { }

  ngOnInit() {
  }

  formOnSumbit(form: NgForm) {
    this.firstSubmit = true;
    if (form.valid) {
      this.router.navigate(['dashboard']);
    }
  }

}
