import { Component, OnInit, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { NgForm, FormGroup, FormControl } from '@angular/forms';

@Component({
  selector: 'app-check-status',
  templateUrl: './check-status.component.html',
  styleUrls: ['./check-status.component.css']
})
export class CheckStatusComponent implements OnInit {

  private url = 'ServiceRequest/Get/';
  formData : FormGroup;

  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') private baseUrl: string
  ) { }

  ngOnInit() {
    this.formData = new FormGroup({
      orderID: new FormControl()
    });
  }
  showID() {
    console.log(this.formData.value.orderID);
  }
  showOrder() {
    return this.http.get(this.baseUrl + this.url+this.formData.value.orderIDds).subscribe(result => {
      console.log(result);
    }, error => {
      console.error(error);
    });
  }
}
