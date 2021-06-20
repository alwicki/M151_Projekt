import { Component } from '@angular/core';
import { ApiService } from './api.service';
import { AuthService } from './auth.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent{
  title = 'RecipeBook';
  recipes: any;
  loggedIn: boolean = false;
  moderator: boolean = false;

  constructor(private api: ApiService, public auth: AuthService){
    this.api.getRecipes().subscribe(res => this.recipes = res);
    this.auth.currentUser.subscribe(res => {
      if(res){
        this.loggedIn = true;
        if(res.userRole==1)this.moderator =true;
      }
  })
}

  logout(){
    this.auth.logout();
    this.loggedIn = false;
  }
}
