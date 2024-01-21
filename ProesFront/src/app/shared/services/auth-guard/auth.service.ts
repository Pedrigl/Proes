import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs/internal/BehaviorSubject';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
    isAuthenticated:boolean = false;
    private authStatusSource = new BehaviorSubject<boolean>(this.checkAuthentication());
    authStatus$ = this.authStatusSource.asObservable();
    
    checkAuthentication() {
        var token = localStorage.getItem('token');
        
        var tokenExpiration = localStorage.getItem('tokenExpiration');
        
        this.isAuthenticated = ((token != null) && (tokenExpiration != null && Date.now() < Date.parse(tokenExpiration)));
        
        return this.isAuthenticated;
    }

    logOut() {
        localStorage.removeItem('token');
        localStorage.removeItem('tokenExpiration');
        this.isAuthenticated = false;
    }

  constructor() { }
}
