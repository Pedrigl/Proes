import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { AuthorizedHttpClientService } from './utils/authorized-http-client.service';
import { EnvironmentUrlService } from './environment-url.service'; 

@Injectable({
  providedIn: 'root'
})
export class UserRepositoryService {
  httpClient!: AuthorizedHttpClientService;
  envUrl: EnvironmentUrlService = new EnvironmentUrlService();

  constructor(private http: HttpClient) {
    this.httpClient = new AuthorizedHttpClientService(http, this.envUrl);
  }


}
