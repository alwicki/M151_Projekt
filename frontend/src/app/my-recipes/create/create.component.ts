import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/auth.service';
import { FormControl } from '@angular/forms'
import { Recipe } from 'src/app/models/recipe';
import { ApiService } from 'src/app/api.service';
import { Tag } from 'src/app/models/tag';

@Component({
  selector: 'app-create',
  templateUrl: './create.component.html',
  styleUrls: ['./create.component.css']
})
export class CreateComponent implements OnInit {

  recipe: Recipe = new Recipe('','',4,[],[],[],this.auth.currentUser)
  selectedTag: any;
  tags: any;
  constructor(public auth: AuthService, public api: ApiService) {
    this.api.getTags().subscribe(res => this.tags=res)
   }

  ngOnInit(): void {
  }

  createRecipe(){
    console.log(this.recipe);
  }

  addTag(){

    if(!this.tags.some(tag=>tag.title === this.selectedTag)){
      this.api.createTag(this.selectedTag).subscribe(res => {
        let tag = new Tag(res, this.selectedTag)
        this.recipe.tags.push(this.selectedTag)})
      console.log('CREATE TAG')
    }
    console.log(this.selectedTag);
    this.selectedTag='';
  }
}
