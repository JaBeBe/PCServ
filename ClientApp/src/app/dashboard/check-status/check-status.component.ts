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
  find = false;
  dataAPI: any = [];
  notFound;
  constructor(
    private get: HttpService
  ) { }
  ngOnInit() {
    this.formData = new FormGroup({
      orderID: new FormControl()
    });
  }

  showOrder() {
    console.log(this.formData.value.orderID);
    let ordId = this.formData.value.orderID;
    this.get.getRequestById(ordId).subscribe(data => {
      this.dataAPI = data;
      console.log(this.dataAPI.result);
      this.find = true;

      if (this.dataAPI.result == null) {
        return this.notFound = true;
      } return this.dataAPI.result;
    }, error => {
      this.find = false;
      this.notFound = true;
      return this.notFound;
      console.error(error);
    });
  }
}
