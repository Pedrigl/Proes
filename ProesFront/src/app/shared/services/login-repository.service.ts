import { Injectable } from '@angular/core';
import { Login, LoginResponse } from '../../Interfaces/login.model';
import { HttpClient } from '@angular/common/http';
import { EnvironmentUrlService } from '../environment-url.service';

@Injectable({
  providedIn: 'root'
})
export class LoginRepositoryService {
  createCompleteRoute(route: string, envAddress: string): string {
    return `${envAddress}/${route}`;
  }

  constructor(private http: HttpClient, private envUrl: EnvironmentUrlService) { }

  userModel!: Login

  public login = (login: Login) => {
    console.log(this.envUrl.urlAddress + "/api/Login/Login");
    return this.http.post<LoginResponse>(this.envUrl.urlAddress + "/api/Login/Login", login);
  }

  public register = (login: Login) => {
    return this.http.post<LoginResponse>(this.envUrl.urlAddress + "/api/Login/Register", login);
  }
}
