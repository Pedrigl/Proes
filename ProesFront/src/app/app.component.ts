import { Component } from '@angular/core';
import { UserModel } from './Interfaces/user.model';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
    user: UserModel = {
        id: 0,
        loginId: 0,
        name: "",
        email: "",
        birthDate: new Date(),
        pictureUrl: ""
    }
    title = 'Proes';

    onUserChanged(user: UserModel) {
        
        this.user = user;
    }
  }

