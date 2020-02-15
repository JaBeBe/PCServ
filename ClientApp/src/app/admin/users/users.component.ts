import { Component, OnInit, Inject } from '@angular/core';
import { HttpService } from 'src/app/shared/http.service';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.css']
})
export class UsersComponent implements OnInit {
  constructor(
    private http: HttpService
  ) {
  }
  ngOnInit() {
    this.http.getUserByLogin("Nespire").subscribe(data=>{
      console.log(data);
    })
  }



}