import { Injectable } from '@angular/core';
import { User } from './models/user'
import { BehaviorSubject, Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  currentUser: User | any = {}

  constructor() { }
}
