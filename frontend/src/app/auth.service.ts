import { Injectable } from '@angular/core';
import { User } from './models/user'
import { BehaviorSubject, Observable } from 'rxjs';
import { JwtHelperService } from '@auth0/angular-jwt';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private currentUserSubject: BehaviorSubject<User>;
  public currentUser: Observable<User>;

  constructor(public jwtHelper: JwtHelperService) { 
    this.currentUserSubject = new BehaviorSubject<User>(JSON.parse(localStorage.getItem('currentUser')));
    this.currentUser = this.currentUserSubject.asObservable();
  }
  
  public get currentUserValue(): User {
    return this.currentUserSubject.value;
}

setUser(user)
{
  localStorage.setItem('currentUser', JSON.stringify(user));
  this.currentUserSubject.next(user);
}

logout() {
  // remove user from local storage to log user out
  localStorage.removeItem('currentUser');
  this.currentUserSubject.next(null);
}

public isAuthenticated(): boolean {
  if(this.currentUserValue != null){
    return !this.jwtHelper.isTokenExpired(this.currentUserValue.token);
  }
  return false;

}


}
