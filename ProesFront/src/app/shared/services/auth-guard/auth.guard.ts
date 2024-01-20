import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree, Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {
  router: Router = new Router();
  isAuthenticated:boolean = false;
    
  canActivate(
    next: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): boolean | UrlTree {
        
    var token = localStorage.getItem('token');
    var tokenExpiration = localStorage.getItem('tokenExpiration');
    this.isAuthenticated = token != null && tokenExpiration != null && Date.now() < Date.parse(tokenExpiration);

    if (this.isAuthenticated) {
      return true;
    }

    else {      
      return this.router.parseUrl('/login');
    }
  }
}
