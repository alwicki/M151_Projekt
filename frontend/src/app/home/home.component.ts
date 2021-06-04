import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
recipes = [1, 2, 3, 4, 5, 6]
  constructor() { }

  ngOnInit(): void {
  }

}
