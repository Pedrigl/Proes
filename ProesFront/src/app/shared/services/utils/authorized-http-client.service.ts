import { Injectable } from '@angular/core';
import { HttpClient, HttpHandler, HttpHeaders } from '@angular/common/http';
import { EnvironmentUrlService } from '../environment-url.service';
import { Observable } from 'rxjs';
import { KeyValue } from '@angular/common';
@Injectable({
  providedIn: 'root'
})
@Injectable()
export class AuthorizedHttpClientService {
  constructor(private client: HttpClient, private envUrl: EnvironmentUrlService) {
    
  }

  addHeaders(headers: KeyValue<string, string>[]): HttpHeaders {
    let httpHeaders = new HttpHeaders();

    headers.forEach(header => {
      httpHeaders = httpHeaders.append(header.key, header.value);
    });

    return httpHeaders;
  }

  getAuthToken(): string {
    let token = localStorage.getItem('token');
    if (token == null) {
      return '';
    }

    return token;
  }

  get<T>(url: string): Observable<T> {
    
    let token = this.getAuthToken();

    let headers = this.addHeaders([
      { key: 'Authorization', value: `Bearer ${token}` }
    ]);
    
    return this.client.get<T>(url, {
      headers: headers
    });
  }

  post<T>(url: string, data: any): Observable<T> {

    let token = this.getAuthToken();

    let headers = this.addHeaders([
      { key: 'Authorization', value: `Bearer ${token}` }
    ]);

    return this.client.post<T>(url, data, {
      headers: headers
    });
  }

  put<T>(url: string, data: any): Observable<T> {

    let token = this.getAuthToken();

    let headers = this.addHeaders([
      { key: 'Authorization', value: `Bearer ${token}` }
    ]);

    return this.client.put<T>(url, data, {
      headers: headers
    });
  }

  delete<T>(url: string): Observable<T> {

    let token = this.getAuthToken();

    let headers = this.addHeaders([
      { key: 'Authorization', value: `Bearer ${token}` }
    ]);

    return this.client.delete<T>(url, {
      headers: headers
    });
  }

  patch<T>(url: string, data: any): Observable<T> {

    let token = this.getAuthToken();

    let headers = this.addHeaders([
      { key: 'Authorization', value: `Bearer ${token}` }
    ]);

    return this.client.patch<T>(url, data, {
      headers: headers
    });
  }


}
