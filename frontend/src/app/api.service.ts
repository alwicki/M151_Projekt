import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  constructor(private http: HttpClient) { }

  getRecipes(){
    return this.http.get('https://localhost:5001/api/recipes');
  }

  register(username: string, password: string){
    var headers = new HttpHeaders({
      'Content-Type': 'application/json',
    });
    return this.http.post('https://localhost:5001/api/users/register', {'username': username, 'password': password}, {headers: headers})
  }

  login(username: string, password: string){
    var headers = new HttpHeaders({
      'Content-Type': 'application/json',
    });
    return this.http.post('https://localhost:5001/api/users/login', {'username': username, 'password': password}, {headers: headers})
  }
}
