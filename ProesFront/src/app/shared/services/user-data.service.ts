import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { UserModel } from 'src/app/Interfaces/user.model';
import { UserRepositoryService } from './repositories/user-repository.service';
import { LoginDataService } from './login-data.service';
@Injectable({
  providedIn: 'root'
})
export class UserDataService {
    private userSubject = new BehaviorSubject<UserModel | null>(this.getUserFromLocalStorage());  

    user$ = this.userSubject.asObservable();

    private getUserFromLocalStorage(): UserModel | null {
        const user = localStorage.getItem("user");
        if (user) {
            return JSON.parse(user);
        }
        return null;
    }
    public setUser(user: UserModel) {
        localStorage.setItem("user", JSON.stringify(user));
        this.userSubject.next(user);
    }

}
