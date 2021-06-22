import { Component, OnInit } from '@angular/core';
import { Ingredient } from 'src/app/models/ingredient';

@Component({
  selector: 'app-detail',
  templateUrl: './detail.component.html',
  styleUrls: ['./detail.component.css']
})
export class DetailComponent implements OnInit {
recipe;
comment;
persons;
oldPersons;
  constructor() { 
    if(history.state.data){
      this.recipe = history.state.data;
      console.log(this.recipe);
      this.persons = this.recipe.persons;
      this.oldPersons = this.recipe.persons;
    }
  }

  ngOnInit(): void {
  }

  recipeSrc(image){
    if(image==null){
      return "/assets/plate.svg"
    }
    return "https://localhost:5001/uploads/"+image
  }

  report(subject, id){
    console.log('REPORT Subject',subject, 'Id',id);
  }

  createComment(){
    console.log('COMMENT', this.comment)
  }

  calcIngredients(){
    this.recipe.ingredients.forEach(ingredient => {
      ingredient.amount=(ingredient.amount/this.oldPersons)*this.persons;
    });
    this.oldPersons=this.persons
  }
}
