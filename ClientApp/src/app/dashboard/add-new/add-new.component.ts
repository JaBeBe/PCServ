import { Component, OnInit, Inject } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { User } from 'src/app/user/user';

@Component({
  selector: 'app-add-new',
  templateUrl: './add-new.component.html',
  styleUrls: ['./add-new.component.css']
})
export class AddNewComponent implements OnInit {

  private url = 'ServiceRequest/Create/request';
  formDataAdd: FormGroup;
  send: boolean = true;
  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') private baseUrl: string
  ) { }

  ngOnInit() {
    this.formDataAdd = new FormGroup({
      stuff: new FormControl(),
      description: new FormControl()
    });
  }
  formToSend = JSON.stringify(this.formDataAdd);
  sendOrder() {
    return this.http.post(this.baseUrl + this.url, this.formToSend).subscribe(result => {
      console.log(result);
      this.send = true;
    }, error => {

      console.log(error);
      this.send = false;
    });
  }
}
