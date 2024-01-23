import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { AuthorizedHttpClientService } from '../utils/authorized-http-client.service';
import { EnvironmentUrlService } from '../environment-url.service'; 
import { UserModel } from '../../../Interfaces/user.model';

@Injectable({
  providedIn: 'root'
})
export class UserRepositoryService {
  httpClient!: AuthorizedHttpClientService;
  envUrl: EnvironmentUrlService = new EnvironmentUrlService();

  constructor(private http: HttpClient) {
    this.httpClient = new AuthorizedHttpClientService(http, this.envUrl);
  }

  public getUserByLoginId = (loginId: number) => {
    return this.httpClient.get<UserModel>(this.envUrl.urlAddress + `/api/User/GetByLoginId?loginId=${loginId}`);
  }

  public getUserById = (id: number) => {
    return this.httpClient.get<UserModel>(this.envUrl.urlAddress + `/api/User/GetByUserId?userId=${id}`);
  }

  public createUser = (user: UserModel) => {
    return this.httpClient.post<UserModel>(this.envUrl.urlAddress + "/api/User/Create", user);
  }

  public updateUser = (user: UserModel) => {
    return this.httpClient.put<UserModel>(this.envUrl.urlAddress + "/api/User/Update", user);
  }

  public deleteUser = (id: number) => {
    return this.httpClient.delete(this.envUrl.urlAddress + `/api/User/Delete?userId=${id}`);
  }
}
