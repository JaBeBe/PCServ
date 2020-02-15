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
  formData: FormGroup;
  find: boolean = true;
  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') private baseUrl: string
  ) { }

  ngOnInit() {
    this.formData = new FormGroup({
      orderID: new FormControl()
    });
    console.log(this.find);
  }
  showID() {
  }
  showOrder() {
    console.log(this.formData.value.orderID);
    return this.http.get(this.baseUrl + this.url + this.formData.value.orderID).subscribe(result => {
      console.log(result);
      this.find=true;
    }, error => {
      this.find = false;
      console.error(error);
    });
  }
}
