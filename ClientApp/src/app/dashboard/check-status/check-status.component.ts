import { Component, OnInit, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { NgForm, FormGroup, FormControl } from '@angular/forms';
import { HttpService } from 'src/app/shared/http.service';

@Component({
  selector: 'app-check-status',
  templateUrl: './check-status.component.html',
  styleUrls: ['./check-status.component.css']
})
export class CheckStatusComponent implements OnInit {

  formData: FormGroup;
  find: boolean = true;
  constructor(
    private get: HttpService
  ) { }

  ngOnInit() {
    this.formData = new FormGroup({
      orderID: new FormControl()
    });
    console.log(this.find);
  }

  showOrder() {
    console.log(this.formData.value.orderID);
    this.get.getRequestById(1).subscribe(data => {
      console.log(data);
      this.find = true;
    }, error => {
      this.find = false;
      console.error(error);
    });
  }
}
