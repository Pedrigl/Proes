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
    

    ngOnInit() {
        this.loginDataService.login$.subscribe({
            next: res => {
                if(res !== null){
                    this.user.loginId = res.id;
                }
            }
        });

        this.userDataService.user$.pipe(
            switchMap(user => {
              if (user !== null) {
                this.user = user;
                return this.userRepository.getUserByLoginId(this.user.loginId);
              }
              // If user is null, return an empty observable
              return of(null);
            })
          ).subscribe({
            next: res => {
              if (res !== null) {
                this.user = res;
                this.userDataService.setUser(res);
              }
            },
            error: err => console.log(err)
          });
    }

    async createUser() {
        try{
            const res = this.userRepository.createUser(this.user);
            const user = await lastValueFrom(res);
            this.user = user;
            console.log(user);
            this.userDataService.setUser(user);
            this.router.navigateByUrl('/home');
        }
        catch(err){
            console.log(err);
        }
    }
  
}
