import { Component, Input, OnInit } from '@angular/core';
import { UserRepositoryService } from '../../shared/services/repositories/user-repository.service';
import { UserModel } from '../../Interfaces/user.model';
import { Router } from '@angular/router';
import { UserDataService } from 'src/app/shared/services/user-data.service';
import { lastValueFrom } from 'rxjs/internal/lastValueFrom';

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
  
    user: UserModel = {
        id: 0,
        name: "",
        birthDate: new Date(),
        email: "",
        loginId: 0,
        pictureUrl: ""
    };
    

    ngOnInit() {
        
        this.userDataService.user$.subscribe({
            next: res => {

                console.log("user page: " + res?.name);
                if(res !== null){
                    this.user = res;
                }
                
            }
        })
    }

    async createUser() {
        try{
            const res = this.userRepository.createUser(this.user);
            const user = await lastValueFrom(res);
            this.user = user;
            this.userDataService.setUser(user);
            this.router.navigateByUrl('/home');
        }
        catch(err){
            console.log(err);
        }
    }
  
}
