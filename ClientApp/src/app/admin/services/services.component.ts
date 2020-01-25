import { Component, OnInit, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-services',
  templateUrl: './services.component.html',
  styleUrls: ['./services.component.css']
})
export class ServicesComponent implements OnInit {

  public services: services[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<services[]>(baseUrl + 'services').subscribe(result => {
      this.services = result;
      console.log(result);
    }, error => console.error(error));
  }
  
  ngOnInit() {
  }

}
interface services {
  Id: number,
  Title: string,
  CreateAt: string,
  Description: string,
  Stuff: string,
  User: string
}