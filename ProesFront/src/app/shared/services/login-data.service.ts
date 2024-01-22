import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs/internal/BehaviorSubject';
import { Login, LoginResponse } from 'src/app/Interfaces/login.model';

@Injectable({
  providedIn: 'root'
})
export class LoginDataService {
    private loginSubject = new BehaviorSubject<LoginResponse | null>(this.getLoginFromLocalStorage());

    login$ = this.loginSubject.asObservable();

    private getLoginFromLocalStorage(): LoginResponse | null {
        const login = localStorage.getItem("login");
        if (login) {
            return JSON.parse(login);
        }
        return null;
    }

    public setLogin(login: LoginResponse) {
        localStorage.setItem("login", JSON.stringify(login));
        this.loginSubject.next(login);
    }
  constructor() { }
}
