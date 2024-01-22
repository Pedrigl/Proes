import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Login, LoginResponse } from '../../Interfaces/login.model';
import { LoginRepositoryService } from '../../shared/services/repositories/login-repository.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import {MenuComponent} from '../../menu/menu.component'; 
import { UserRepositoryService } from '../../shared/services/repositories/user-repository.service';
import { UserModel } from 'src/app/Interfaces/user.model';
import { UserDataService } from 'src/app/shared/services/user-data.service';
import { first } from 'rxjs/operators';
import { lastValueFrom } from 'rxjs';
import { AuthService } from 'src/app/shared/services/auth-guard/auth.service';
@Component({
  selector: 'app-login-page',
  templateUrl: './login-page.component.html',
  styleUrls: ['./login-page.component.css']
})
export class LoginPageComponent implements OnInit{
  constructor(
    private router:Router, 
    private loginRepository: LoginRepositoryService, 
    private userRepository: UserRepositoryService,
    private userDataService: UserDataService,
    private authService: AuthService) {
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
    try{
        const res = this.loginRepository.login(this.login);
        const login = await lastValueFrom(res);
        
        this.saveToken(login.token, login.tokenExpiration);
        this.authService.setAuthenticationStatus(true);
        await this.checkForUser(login.id);

        if (this.userExists) {
            console.log("User exists, navigating to /home");
            this.router.navigate(['/home']);
        } 
        
        else {
            console.log("User does not exist, navigating to /user");
            this.router.navigate(['/user']);
        }
    }

    catch(err){
        console.log(err);
        this.loginError = true;
    }
  }

  public async registerSubmit() {
    try{
        const res = this.loginRepository.register(this.login);
        const login = await lastValueFrom(res);
        this.login.username = login.username;
        this.login.password = login.password;
        this.login.userType = login.userType;
        this.loginSubmit();
    }
    
    catch(err){
        console.log(err);
        this.registerError = true;
    }
  }
  
  private async checkForUser(loginId: number): Promise<void> {
    
    try{
        const res = await this.userRepository.getUserByLoginId(loginId);
        const user = await lastValueFrom(res);
        
        this.userExists = user.id > 0;
        if(this.userExists){
            this.userDataService.setUser(user);
        }
        
    }

    catch(err){
        console.log(err);
    }
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
