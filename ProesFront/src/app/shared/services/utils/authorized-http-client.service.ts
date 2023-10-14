import { Injectable } from '@angular/core';
import { HttpClient, HttpHandler, HttpHeaders } from '@angular/common/http';
import { EnvironmentUrlService } from '../../environment-url.service';
@Injectable({
  providedIn: 'root'
})
@Injectable()
export class AuthorizedHttpClientService {
  constructor(private client: HttpClient, private envUrl: EnvironmentUrlService) {
  }

  createAuthorizationHeader(headers :HttpHeaders): void {
    headers.append('Authorization', 'Bearer ' + localStorage.getItem('token'));
  }

  get(url: string) {
    let headers = new HttpHeaders();
    this.createAuthorizationHeader(headers);
    return this.client.get(this.envUrl.urlAddress + url, {
      headers: headers
    });
  }

  post(url: string, data: any) {
    let headers = new HttpHeaders();
    this.createAuthorizationHeader(headers);
    return this.client.post(this.envUrl.urlAddress + url, data, {
      headers: headers
    });
  }
}
