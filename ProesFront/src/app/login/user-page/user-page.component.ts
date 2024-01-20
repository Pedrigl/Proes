import { Component, Input, OnInit } from '@angular/core';
import { UserRepositoryService } from '../../shared/services/repositories/user-repository.service';
import { UserModel } from '../../Interfaces/user.model';
import { Router } from '@angular/router';
import { UserDataService } from 'src/app/shared/services/user-data.service';

@Component({
  selector: 'app-user-page',
  templateUrl: './user-page.component.html',
  styleUrls: ['./user-page.component.css']
})
export class UserPageComponent implements OnInit{
  constructor(
    private userRepository: UserRepositoryService,
    private userDataService: UserDataService,
    private router: Router) {
  }
  
    user!: UserModel

    ngOnInit() {
        this.userDataService.user$.subscribe({
            next: res => {

                if(res !== null){
                    this.user = res;
                }
                
            }
        })
    }


    async getUserByLoginId() {
        this.userRepository.getUserByLoginId(this.user.loginId)
        .subscribe({
            next: res => {
                this.user = res;
                this.router.navigateByUrl('/home');
            },
            error: err => {
                console.log(err);
            }
        })
    }

    async createUser() {
        this.userRepository.createUser(this.user)
        .subscribe({
            next: res => {
                this.user = res;
                this.router.navigateByUrl('/home');
            },
            error: err => {
                console.log(err);
            }
        })
    }
  
}
