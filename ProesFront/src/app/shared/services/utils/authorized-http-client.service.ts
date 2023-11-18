import { Injectable } from '@angular/core';
import { HttpClient, HttpHandler, HttpHeaders } from '@angular/common/http';
import { EnvironmentUrlService } from '../environment-url.service';
import { Observable } from 'rxjs';
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

  get<T>(url: string): Observable<T> {
    let headers = new HttpHeaders();
    this.createAuthorizationHeader(headers);
    return this.client.get<T>(this.envUrl.urlAddress + url, {
      headers: headers
    });
  }

  post<T>(url: string, data: any): Observable<T> {
    let headers = new HttpHeaders();
    this.createAuthorizationHeader(headers);
    return this.client.post<T>(this.envUrl.urlAddress + url, data, {
      headers: headers
    });
  }
}
