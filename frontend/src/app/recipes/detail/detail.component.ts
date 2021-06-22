import { Component, OnInit } from '@angular/core';
import { Ingredient } from 'src/app/models/ingredient';
import { Comment } from 'src/app/models/comment'
import { ApiService } from 'src/app/api.service';

@Component({
  selector: 'app-detail',
  templateUrl: './detail.component.html',
  styleUrls: ['./detail.component.css']
})
export class DetailComponent implements OnInit {
recipe;
commentText;
persons;
oldPersons;
showCommentForm =false;
  constructor(public api: ApiService) { 
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
    let comment = new Comment(null, this.commentText, null, null, null, this.recipe.recipeId);
    console.log('COMMENT', comment)
    this.api.createComment(comment).subscribe(res => this.recipe.comments.push(res));
  }

  calcIngredients(){
    this.recipe.ingredients.forEach(ingredient => {
      ingredient.amount=(ingredient.amount/this.oldPersons)*this.persons;
    });
    this.oldPersons=this.persons
  }

}
