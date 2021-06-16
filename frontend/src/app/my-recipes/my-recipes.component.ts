import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ApiService } from '../api.service';
import { AuthService } from '../auth.service';

@Component({
  selector: 'app-my-recipes',
  templateUrl: './my-recipes.component.html',
  styleUrls: ['./my-recipes.component.css']
})
export class MyRecipesComponent implements OnInit {
  recipes;
  user;
  constructor(public api: ApiService, public auth: AuthService, public router: Router) { 
    console.log(this.auth.currentUser);
    this.auth.currentUser.subscribe(user => this.user = user)
    this.api.getUserRecipes(this.user.userId).subscribe(res => {this.recipes = res; console.log(res)});
  }

  ngOnInit(): void {
  }

  editRecipe(recipe){
    this.router.navigate(['myrecipes/create'], {state: {data: recipe}})
  }

}
