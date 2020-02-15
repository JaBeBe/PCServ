import { Component, OnInit, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.css']
})
export class UsersComponent implements OnInit {

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get(baseUrl + 'user/search/Nespire').subscribe(result => {
      console.log("List of users: " + JSON.stringify(result));
    }, error => console.error(error));
  }
  ngOnInit() {
  }

}