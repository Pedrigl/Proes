import { Component } from '@angular/core';
import { UserRepositoryService } from '../../shared/services/user-repository.service';
import { UserModel } from '../../Interfaces/user.model';
import { Router } from '@angular/router';
@Component({
  selector: 'app-user-page',
  templateUrl: './user-page.component.html',
  styleUrls: ['./user-page.component.css']
})
export class UserPageComponent {
  constructor(private userRepository: UserRepositoryService, private router: Router) {
  }

  user!: UserModel

  async createUser() {
    
    this.userRepository.createUser(this.user)
      .subscribe(res => {
        this.user = res;

        this.router.navigateByUrl('/home');
      },
        err => {
          console.log(err);
        })

  }
  
}
