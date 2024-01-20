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

    this.isAuthenticated = localStorage.getItem('token') != null;

    if (this.isAuthenticated) {
      return true;
    }

    else {      
      return this.router.parseUrl('/login');
    }
  }
}
