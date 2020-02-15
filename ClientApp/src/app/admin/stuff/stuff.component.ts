import { Component, OnInit, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-stuff',
  templateUrl: './stuff.component.html',
  styleUrls: ['./stuff.component.css']
})
export class StuffComponent implements OnInit {

  idProduct:number = 123;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get(baseUrl + 'product/search/'+this.idProduct).subscribe(result => {
      console.log("List of products: "+JSON.stringify(result));
    }, error => console.error(error));
  }
  ngOnInit() {
  }

}
