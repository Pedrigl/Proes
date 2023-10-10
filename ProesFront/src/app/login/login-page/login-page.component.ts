import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Login, LoginResponse } from '../../Interfaces/login.model';
import { LoginRepositoryService } from '../../shared/services/login-repository.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import {Router} from '@angular/router'; 
@Component({
  selector: 'app-login-page',
  templateUrl: './login-page.component.html',
  styleUrls: ['./login-page.component.css']
})
export class LoginPageComponent{
  constructor(private router:Router, private loginRepository: LoginRepositoryService) {
  }
  loginError: boolean = false;

  registerError: boolean = false;
  registerMode: boolean = false;
  registerErrorMessage!: string;

  login: Login = {
    username: "",
    password: ""

  };

  public registerModeToggle() {
    this.registerMode = !this.registerMode;
    console.log(this.registerMode)
  }

  public loginSubmit() {
    this.loginRepository.login(this.login)
      .subscribe(res => {
        localStorage.setItem('token', res.token);
        this.router.navigateByUrl('/home');
      },
      error => this.loginError = true);
  }

  public registerSubmit(){
    this.loginRepository.register(this.login)
      .subscribe(res => {
        console.log(res);
        this.login.username = res.username;
        this.login.password = res.password;
        this.loginSubmit();
      },
        error => {
          this.registerErrorMessage = error;
          this.registerError = true;
          console.log(error)
        });
  }

}
