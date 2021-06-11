import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/auth.service';
import { FormControl } from '@angular/forms'
import { Recipe } from 'src/app/models/recipe';
import { ApiService } from 'src/app/api.service';
import { Tag } from 'src/app/models/tag';
import { Ingredient } from 'src/app/models/ingredient';
import { THIS_EXPR } from '@angular/compiler/src/output/output_ast';

@Component({
  selector: 'app-create',
  templateUrl: './create.component.html',
  styleUrls: ['./create.component.css']
})
export class CreateComponent implements OnInit {

  recipe: Recipe = new Recipe('','',4,[],[],[],this.auth.currentUser)
  selectedTag: any;
  tags: any;
  ingredient: Ingredient = new Ingredient();
  constructor(public auth: AuthService, public api: ApiService) {
    this.api.getTags().subscribe(res => this.tags=res)
   }

  ngOnInit(): void {
  }

  createRecipe(){
    console.log(this.recipe);
  }

  addTag(){
    const title = this.selectedTag;
    if(!this.tags.some(tag=>tag.title === this.selectedTag)){
      this.api.createTag(this.selectedTag).subscribe(res => {
        let tag = new Tag(res, title)
        this.recipe.tags.push(tag)})
      console.log('CREATE TAG')
    }
    else{
      this.recipe.tags.push(this.tags.find(tag => tag.title === this.selectedTag))
    }
    console.log(this.recipe.tags);
    console.log(this.selectedTag);
    this.selectedTag='';
  }

  removeTag(id){
    this.recipe.tags = this.recipe.tags.filter(tag => tag.id != id);
  }

  addIngredient(){
    const ingredient = this.ingredient
    console.log(this.ingredient);
    this.recipe.ingredients.push(ingredient);
    
    console.log(this.recipe.ingredients);
    this.ingredient = new Ingredient();
  }

  removeIngredient(){
    console.log(this.ingredient);
  }
}
