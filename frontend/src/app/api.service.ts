import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AuthService } from './auth.service';
import { IImage } from './models/image';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

 token
  constructor(private http: HttpClient, public auth: AuthService) {
    this.auth.currentUser.subscribe(res => 
      {
        if(res.token){
          this.token =res.token
      }
   });
  }

  getRecipes(){
    var headers = new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${this.token}`,
    });
    return this.http.get('https://localhost:5001/api/recipes', {headers: headers});
  }

  getUserRecipes(id){
    var headers = new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${this.token}`,
    });
    return this.http.get('https://localhost:5001/api/recipes/user/'+id, {headers: headers});
  }

  getToken(){
    var headers = new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${this.token}`,
    });
    return this.http.get('https://localhost:5001/api/recipes/token', {headers: headers});
  }

  getTags(){
    var headers = new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${this.token}`,
    });
    return this.http.get('https://localhost:5001/api/tags', {headers: headers});
  }

  createTag(title: string){
    var headers = new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${this.token}`,
    });
    return this.http.post<number>('https://localhost:5001/api/tags/create', {'title': title}, {headers: headers})
  }

  getUnits(){
    var headers = new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${this.token}`,
    });
    return this.http.get('https://localhost:5001/api/units');
  }

  createUnit(title: string){
    var headers = new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${this.token}`,
    });
    return this.http.post<number>('https://localhost:5001/api/units/create', {'title': title}, {headers: headers})
  }

  createRecipe(recipe){
    var headers = new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${this.token}`,
    });
    return this.http.post<number>('https://localhost:5001/api/recipes/create', recipe, {headers: headers})
  }

  createComment(comment){
    var headers = new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${this.token}`,
    });
    return this.http.post<Comment>('https://localhost:5001/api/comments/create', comment, {headers: headers})
  }


  updateRecipe(recipe){
    var headers = new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${this.token}`,
    });
    return this.http.post<number>('https://localhost:5001/api/recipes/update', recipe, {headers: headers})
  }

  register(username: string, password: string){
    var headers = new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${this.token}`,
    });
    return this.http.post('https://localhost:5001/api/users/register', {'username': username, 'password': password}, {headers: headers})
  }

  login(username: string, password: string){
    var headers = new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${this.token}`,
    });
    return this.http.post('https://localhost:5001/api/users/login', {'username': username, 'password': password}, {headers: headers})
  }

  uploadRecipeImage(file: File){
    var headers = new HttpHeaders({
      'Authorization': `Bearer ${this.token}`,
    });
    const formData = new FormData();
    formData.append('recipeImage', file);
    return this.http.post<IImage>('https://localhost:5001/api/recipes/image', formData, {headers: headers});
  }
}
