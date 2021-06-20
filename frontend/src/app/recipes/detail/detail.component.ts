import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-detail',
  templateUrl: './detail.component.html',
  styleUrls: ['./detail.component.css']
})
export class DetailComponent implements OnInit {
recipe;
comment;
  constructor() { 
    if(history.state.data){
      this.recipe = history.state.data;
      console.log(this.recipe);
    }
  }

  ngOnInit(): void {
  }

  report(subject, id){
    console.log('REPORT Subject',subject, 'Id',id);
  }

  createComment(){
    console.log('COMMENT', this.comment)
  }
}
