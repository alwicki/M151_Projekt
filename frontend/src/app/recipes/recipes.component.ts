import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-recipes',
  templateUrl: './recipes.component.html',
  styleUrls: ['./recipes.component.css']
})
export class RecipesComponent implements OnInit {
  recipes = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10]
  tags = ['vegetarian', 'soup', 'meat', 'lactose free']
  showFilter = false;
  constructor() { }

  ngOnInit(): void {
  }

}
