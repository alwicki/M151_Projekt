import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/auth.service';
import { FormControl } from '@angular/forms'
import { Recipe } from 'src/app/models/recipe';
import { ApiService } from 'src/app/api.service';
import { Tag } from 'src/app/models/tag';
import { Ingredient } from 'src/app/models/ingredient';
import { Unit } from 'src/app/models/unit';
import { Step } from 'src/app/models/order';
import { IImage } from 'src/app/models/image';
import { read } from '@popperjs/core';

@Component({
  selector: 'app-create',
  templateUrl: './create.component.html',
  styleUrls: ['./create.component.css']
})
export class CreateComponent implements OnInit {

  recipe: Recipe = new Recipe(0, '','',4,null,[],[],[],[],this.auth.currentUserValue)
  selectedTag: any;
  tags: any;
  selectedUnit: any;
  units: any;
  fileBlob: any;
  ingredient: Ingredient = new Ingredient();
  step: Step = new Step();
  update = false;
  recipeImg;
  constructor(public auth: AuthService, public api: ApiService) {
    this.api.getTags().subscribe(res => this.tags=res)
    this.api.getUnits().subscribe(res=> this.units=res)
    console.log(history.state.data);
    if(history.state.data){
      this.recipe = history.state.data;
      this.recipeImg = "https://localhost:5001/uploads/"+this.recipe.image;
      this.update = true;
    }
   }

  ngOnInit(): void {
  }

  changeFile(file){
    return new Promise((resolve, reject) => {
      const reader = new FileReader();
      reader.readAsDataURL(file);
      reader.onload = () => resolve(reader.result);
      reader.onerror = error => reject(error);
    })
  }

  image(event){
      const file = event.target.files[0];
      const type = file.type;
      console.log(type);
      this.changeFile(file).then((base64: string): any => {
        console.log(base64);
        this.api.uploadRecipeImage(file).subscribe(res => {
          this.recipe.image=res.image;
          this.recipeImg = "https://localhost:5001/uploads/"+res.image
          console.log(res);          
          ;});
      });
  }

  b64Blob(b64, type){
    return new Blob([b64], {type: type})
  }

  createRecipe(){
    console.table(this.recipe);
    this.api.createRecipe(this.recipe).subscribe(res => console.log(res));
  }

  updateRecipe(){
    console.log(this.recipe);
    this.api.updateRecipe(this.recipe).subscribe(res => console.log(res));
  }

  addTag(){
    const title = this.selectedTag;
    if(title == null || title == '') return;
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
    console.log('Filter id', id);
    this.recipe.tags = this.recipe.tags.filter(tag => tag.tagId != id);
    console.log('After filter', this.recipe.tags);
  }

  addIngredient(){
    const ingredient = this.ingredient
    if(ingredient.description == null || ingredient.description == '') return;
    if(!this.units.some(unit=>unit.title === this.selectedUnit)){
      this.api.createUnit(this.selectedUnit).subscribe(res => {
        let unit = new Unit(res, this.selectedUnit)
        ingredient.unit=unit
        ingredient.unitId=unit.unitId
      })
      console.log('CREATE TAG')
    }
    else{
      this.ingredient.unit = this.units.find(unit => unit.title === this.selectedUnit)
      this.ingredient.unitId = this.ingredient.unit.unitId
    }
    console.log(this.ingredient);
    this.recipe.ingredients.push(ingredient);
    
    console.log("RECIPE INGREDIENTS",this.recipe.ingredients);
    this.ingredient = new Ingredient();
  }

  removeIngredient(description){
    console.log(this.recipe.ingredients);
    this.recipe.ingredients = this.recipe.ingredients.filter(ingredient => ingredient.description != description);
  }

  addStep(){
    const step = this.step
    if(step.description == null || step.description == '') return;
    step.order = this.recipe.steps.length+1;
    this.recipe.steps.push(step);
    this.step = new Step();
  }

  removeStep(description){
    this.recipe.steps = this.recipe.steps.filter(step => step.description != description);
  }

  changeDescription(event){
    this.recipe.description = event.target.value;
  }
}
