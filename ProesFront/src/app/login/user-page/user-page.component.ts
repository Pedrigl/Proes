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

  

  async checkForUser(loginId: number): Promise<boolean> {
    let user = await this.userRepository.getUserByLoginId(loginId).toPromise();
    return user != null;
  }
}
