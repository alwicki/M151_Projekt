import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ApiService } from '../api.service';

@Component({
  selector: 'app-recipes',
  templateUrl: './recipes.component.html',
  styleUrls: ['./recipes.component.css']
})
export class RecipesComponent implements OnInit {
  recipes
  tags
  showFilter = false;
  constructor( public api: ApiService, public router: Router) { }

  ngOnInit(): void {
    this.api.getRecipes().subscribe(res => this.recipes = res);
    this.api.getTags().subscribe(res => this.tags = res);
  }

  showDetail(recipe){
    this.router.navigate(['recipes/detail'], {state: {data: recipe}})
  }

}
