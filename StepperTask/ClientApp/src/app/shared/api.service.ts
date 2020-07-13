import { Injectable } from '@angular/core';
import { HttpClient, HttpEvent } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  constructor(private http: HttpClient) { }

  //get all Data
  get(url): Observable<any> {
    return this.http.get<any>(url);
  }

  //post Data
  post(url, data): Observable<any> {
    return this.http.post<any>(url, data);
  }

  //put Data
  put(url, data): Observable<any> {
    return this.http.put<any>(url, data);
  }

  //delete Data
  delete(url): Observable<any> {
    return this.http.delete<any>(url);
  }

}
