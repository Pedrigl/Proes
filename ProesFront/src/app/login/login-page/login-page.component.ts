import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Login, LoginResponse } from '../../Interfaces/login.model';
import { LoginRepositoryService } from '../../shared/services/login-repository.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import {MenuComponent} from '../../menu/menu.component'; 
import { UserRepositoryService } from '../../shared/services/user-repository.service';

@Component({
  selector: 'app-login-page',
  templateUrl: './login-page.component.html',
  styleUrls: ['./login-page.component.css']
})
export class LoginPageComponent implements OnInit{
  constructor(private router:Router, private loginRepository: LoginRepositoryService, private userRepository: UserRepositoryService) {
  }

  loginError: boolean = false;
  registerError: boolean = false;
  registerMode: boolean = false;
  registerErrorMessage!: string;
  userExists: boolean = false;

  login: Login = {
    username: "",
    password: ""

  };

  public registerModeToggle() {
    this.registerMode = !this.registerMode;
  }

  public async loginSubmit() {
    this.loginRepository.login(this.login)
      .subscribe(res => {
        localStorage.setItem('token', res.token);
        
        this.checkForUser(res.id);
        if (this.userExists) {
          this.router.navigate(['/home']);
        }

        else {
          this.router.navigate(['/user']);
        }
      },
        error => {
          console.log(error);
          this.loginError = true;
        });
  }

  public registerSubmit(){
    this.loginRepository.register(this.login)
      .subscribe(res => {
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

  private checkForUser(loginId: number): void {
    this.userRepository.getUserByLoginId(loginId)
      .subscribe(res => {
        this.userExists = res.id != null;
      },
        (err: HttpErrorResponse) => {
          console.log(err.status)
          console.log(err.statusText)
          console.log(err.url)
          console.log(err.message);
        });
  }

  ngOnInit(): void {
      localStorage.removeItem('token');
  }

}
