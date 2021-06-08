import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { Router } from '@angular/router';
import { ApiService } from '../api.service';
@Component({
  selector: 'app-start',
  templateUrl: './start.component.html',
  styleUrls: ['./start.component.css'],
})
export class StartComponent implements OnInit {
  loginForm = new FormGroup({
    username: new FormControl(''),
    password: new FormControl(''),
  });

  registerForm = new FormGroup({
    username: new FormControl(''),
    password: new FormControl(''),
    passwordRepeat: new FormControl(''),
  });

  login = true;

  constructor(public api: ApiService, public router: Router) {}

  ngOnInit(): void {}

  loginUser() {
    console.log(this.loginForm.value);
    this.api.login(this.loginForm.get('username')?.value, this.loginForm.get('password')?.value).subscribe(
      res => console.log(res),
      (err)=> console.log('error'),
      ()=>{
        this.router.navigate(['recipes'])
      }
      
      );
  }

  registerUser() {
    console.log(this.registerForm.value);
    if (
      this.registerForm.get('password')?.value !=
      this.registerForm.get('passwordRepeat')?.value
    ) {
      console.log("passwords don't match");
    } else {
      this.api
        .register(
          this.registerForm.get('username')?.value,
          this.registerForm.get('password')?.value
        )
        .subscribe((res) => console.log(res),
        (err)=>{console.log('error')},
        ()=>this.login=true);
    }
  }
}
