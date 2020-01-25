import { Component, OnInit, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.css']
})
export class UsersComponent implements OnInit {

  public users: users[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<users[]>(baseUrl + 'users').subscribe(result => {
      this.users = result;
      console.log(result);
    }, error => console.error(error));
  }
  ngOnInit() {
  }

}

interface users{
  Id: number,
  FirstName: string,
  LastName: string,
  Login: string,
  Password: string,
  Role: string,
  CreateTime: string
}