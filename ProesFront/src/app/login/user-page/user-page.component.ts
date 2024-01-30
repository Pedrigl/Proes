import { Component, Input, OnInit } from '@angular/core';
import { UserRepositoryService } from '../../shared/services/repositories/user-repository.service';
import { UserModel } from '../../Interfaces/user.model';
import { Router } from '@angular/router';
import { UserDataService } from 'src/app/shared/services/user-data.service';
import { lastValueFrom } from 'rxjs/internal/lastValueFrom';
import { LoginDataService } from 'src/app/shared/services/login-data.service';
import { switchMap } from 'rxjs/internal/operators/switchMap';
import { of } from 'rxjs/internal/observable/of';

@Component({
  selector: 'app-user-page',
  templateUrl: './user-page.component.html',
  styleUrls: ['./user-page.component.css']
})
export class UserPageComponent implements OnInit{
  constructor(
    private userRepository: UserRepositoryService,
    private userDataService: UserDataService,
    private loginDataService: LoginDataService,
    private loginRepository: LoginDataService,
    private router: Router) {
  }
  
    user: UserModel = {
        id: 0,
        name: "",
        birthDate: new Date(),
        email: "",
        loginId: 0,
        pictureUrl: ""
  };

    registerUserError: boolean = false;
    registerUserErrorMessage!: string;

  ngOnInit() {
    this.loginDataService.login$.subscribe({
      next: res => {
        if (res !== null) {
          this.user.loginId = res.id;
        }
      }
    });

    this.userDataService.user$.subscribe({
      next: res => {
        if (res !== null) {
          this.user = res;
        }
      },
      error: err => {
        console.log(err);
      }
    });

    if (this.user.id == 0) {
      try {
        this.userRepository.getUserByLoginId(this.user.loginId).subscribe({
          next: res => {
            if (res != null) {
              this.user = res;
              this.userDataService.setUser(res);
            }
          },
          error: err => {
            console.log(err);
          }
        });
      }

      catch (ex) {
        console.log(ex);
      }
    }
  }

  async createUser() {
    try {
      const res = this.userRepository.createUser(this.user);
      const user = await lastValueFrom(res);
      this.user = user;
      this.userDataService.setUser(user);
      this.router.navigateByUrl('/home');
    }
    catch (err: any) {
      this.registerUserError = true;
      this.registerUserErrorMessage = err.error;
      console.log(err);
    }
  }

  async updateUser() {
    try {
      const res = this.userRepository.updateUser(this.user);
      const user = await lastValueFrom(res);
      this.user = user;
      this.userDataService.setUser(user);
      this.router.navigateByUrl('/home');
    }

    catch (err: any) {
      this.registerUserError = true;
      this.registerUserErrorMessage = err.error;
      console.log(err);
    }
  }
    async saveUser() {

      if (this.user.id === 0) {
      await this.createUser();
    }
    else {
      await this.updateUser();
    }

  }
  
  
}
