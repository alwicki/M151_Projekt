import { Component, OnInit } from '@angular/core';
import { ApiService } from '../api.service';

@Component({
  selector: 'app-moderator',
  templateUrl: './moderator.component.html',
  styleUrls: ['./moderator.component.css']
})
export class ModeratorComponent implements OnInit {
  reports;
  data;
  constructor(public api: ApiService) { 
    this.api.getReports().subscribe(res=>{console.log(res)
    this.reports = res});
  }

  ngOnInit(): void {
  }

  showData(topic, id){
    if(topic == 'comment'){
      this.api.getComment(id).subscribe(res=> {
        this.data =res
      })
    }
    else if(topic == 'recipe'){
      this.api.getRecipe(id).subscribe(res=>{console.log(res);
        this.data=res})
    }
  }

  recipeSrc(image){
    if(image==null){
      return "/assets/plate.svg"
    }
    return "https://localhost:5001/uploads/"+image
  }

}
