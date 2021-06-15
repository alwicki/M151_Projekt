import { Component, OnInit } from '@angular/core';
import { ApiService } from '../api.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
recipes: any;
  constructor(public api: ApiService) { 
    this.api.getRecipes().subscribe(res => this.recipes = res);
  }

  ngOnInit(): void {
  }

}
