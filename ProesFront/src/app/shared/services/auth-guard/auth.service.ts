import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
    isAuthenticated:boolean = false;

    checkAuthentication() {
        var token = localStorage.getItem('token');
        
        var tokenExpiration = localStorage.getItem('tokenExpiration');
        
        this.isAuthenticated = ((token != null) && (tokenExpiration != null && Date.now() < Date.parse(tokenExpiration)));
        
        return this.isAuthenticated;
    }

  constructor() { }
}
