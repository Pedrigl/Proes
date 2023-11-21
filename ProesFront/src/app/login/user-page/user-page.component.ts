import { Component } from '@angular/core';
import { UserRepositoryService } from '../../shared/services/user-repository.service';
import { UserModel } from '../../Interfaces/user.model'; 
@Component({
  selector: 'app-user-page',
  templateUrl: './user-page.component.html',
  styleUrls: ['./user-page.component.css']
})
export class UserPageComponent {
  constructor(private userRepository: UserRepositoryService) {
  }

  user!: UserModel

  async createUser() {
    this.userRepository.createUser(this.user)
      .subscribe(res => {
        this.user = res;
      },
        err => {
          console.log(err);
        })

  }
  
}
