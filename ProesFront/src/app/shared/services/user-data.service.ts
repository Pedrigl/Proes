import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { UserModel } from 'src/app/Interfaces/user.model';

@Injectable({
  providedIn: 'root'
})
export class UserDataService {
    private userSubject = new BehaviorSubject<UserModel | null>(null);  
    user$ = this.userSubject.asObservable();

    public setUser(user: UserModel) {
        this.userSubject.next(user);
    }

  constructor() { }
}
