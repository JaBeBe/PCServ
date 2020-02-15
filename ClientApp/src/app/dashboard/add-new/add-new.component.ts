import { Component, OnInit, Inject } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { User } from 'src/app/user/user';
import * as jwt_decode from "jwt-decode";
import { HttpService } from 'src/app/shared/http.service';

@Component({
  selector: 'app-add-new',
  templateUrl: './add-new.component.html',
  styleUrls: ['./add-new.component.css']
})
export class AddNewComponent implements OnInit {

  formDataAdd: FormGroup;
  send: boolean = true;

  constructor(
    private http: HttpService

  ) { }

  ngOnInit() {
    this.formDataAdd = new FormGroup({
      stuff: new FormControl(),
      description: new FormControl()
    });
  }
  formToSend = JSON.stringify(this.formDataAdd);

  sendOrder(service: newService) {

    service["Id"];
    service["CreateAt"];
    service["StuffId"] = 4;
    service["ClientId"] = 4;

    console.log(service);
    this.http.postRequest(service).subscribe(data=>{
      console.log(data);
    })
  }

}

export interface newService {
  Id: number;
  Title: string;
  CreateAt: string;
  Description: string;
  StuffId: number;
  ClientId: number;
}

