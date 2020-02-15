import { Component, OnInit, Inject } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { User } from 'src/app/user/user';

@Component({
  selector: 'app-add-new',
  templateUrl: './add-new.component.html',
  styleUrls: ['./add-new.component.css']
})
export class AddNewComponent implements OnInit {

  private url = 'serviceRequest/create';
  formDataAdd: FormGroup;
  send: boolean=true;
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
  sendOrder(service: newService) {
    service["Id"] = 4;
    service["CreateAt"] ="2012-04-30T02:15:12.356Z";
    service["StuffId"] = 4;
    service["ClientId"] = 4;
    console.log(Date.now());

    console.log(service);
    const headers = new HttpHeaders().set('Content-Type', 'application/json');

    return this.http.post(this.baseUrl + 'requestHistory/create', service).subscribe(
      status=> console.log(JSON.stringify(status)
      ));

  }
  
}
export interface newService {
  Id:number;
  Title: string;
  CreateAt: string;
  Description: string;
  StuffId: number;
  ClientId: number;
}

