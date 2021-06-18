import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ApiService } from '../api.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
recipes: any;
  constructor(public api: ApiService, public router: Router) { 
    this.api.getRecipes().subscribe(res => this.recipes = res);
  }

  ngOnInit(): void {
  }


  showDetail(recipe){
    this.router.navigate(['recipes/detail'], {state: {data: recipe}})
  }
}
