import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree, Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {
  router: Router = new Router();
  isAuthenticated = !!localStorage.getItem('token');
  canActivate(
    next: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): boolean | UrlTree {

    if (this.isAuthenticated) {
      return true;
    }

    else {      
      return this.router.parseUrl('/login');
    }
  }
}
