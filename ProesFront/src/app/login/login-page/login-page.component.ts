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
    password: "",
    userType: 0
  };

  public registerModeToggle() {
    this.registerMode = !this.registerMode;
  }

  public async loginSubmit() {
    this.loginRepository.login(this.login)
    .subscribe({
        next: async res => {
            
            this.saveToken(res.token, res.tokenExpiration);

            await this.checkForUser(res.id);

            if (this.userExists) {
                console.log("User exists, navigating to /home");
                this.router.navigate(['/home']);
            } 
            
            else {
                console.log("User does not exist, navigating to /user");
                this.router.navigate(['/user']);
            }
            
        },
        error: err => {
            console.log(err);
            this.loginError = true;
        }
    });
  }

  public registerSubmit() {
    this.loginRepository.register(this.login)
    .subscribe({
        next: res => {
            this.login.username = res.username;
            this.login.password = res.password;
            this.login.userType = res.userType;
            this.loginSubmit();
        },
        error: err => {
            console.log(err);
        }
    });
  }
  
  private async checkForUser(loginId: number): Promise<void> {
    
       this.userRepository.getUserByLoginId(loginId)
       .subscribe({
            next: res => {
            this.userExists = res.id > 0;
            console.log("User exists: " + this.userExists);
            },
            error: (err: HttpErrorResponse) => {
            console.log(err);
            }
       });
  }

  public saveToken(token: string, tokenExpiration: Date) {
    localStorage.removeItem('token');
    localStorage.setItem('token', token);
    localStorage.removeItem('tokenExpiration');
    localStorage.setItem('tokenExpiration', tokenExpiration.toString());
  }
  
  ngOnInit(): void {
      localStorage.removeItem('token');
  }

}
