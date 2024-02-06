import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree, Router } from '@angular/router';
import { AuthService } from './auth.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {
  router: Router = new Router();
  isAuthenticated:boolean = false;
    constructor(private authService: AuthService) { }
  canActivate(
    next: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): boolean | UrlTree {
    this.authService
    this.authService.checkAuthentication();

    const expectedRole = next.data["expectedRole"];
    const currentRole = this.authService.getRole();

    if (this.authService.isAuthenticated && currentRole != expectedRole) {
        return true;
    } else {
        return this.router.parseUrl('/login');
    }
  }
}
