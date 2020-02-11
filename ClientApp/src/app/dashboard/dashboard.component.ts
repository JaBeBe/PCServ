import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {
  showAddVariable = false;
  checkStatusVariable = false;
  constructor() { }
  ngOnInit() {
  }
  showAdd() {
    this.checkStatusVariable = false;
    this.showAddVariable = true;
  }
  showStatus() {
    this.showAddVariable = false;
    this.checkStatusVariable = true;
  }
}
