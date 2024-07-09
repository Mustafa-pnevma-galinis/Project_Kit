import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { User } from '../Core/Model/User.Model';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ApiConnectionService {

  constructor(private http: HttpClient) { 

  }

    addUser(model: User): Observable<void>{
      return this.http.post<void>(`${environment.apiURL}/api/Form`,model);
    }

    getgovs(): Observable<any[]>{
      return this.http.get<any[]>(`${environment.apiURL}/api/Form`);
    }

    getCitiesBygov(gov?: string): Observable<any[]>{
      return this.http.get<any[]>(`${environment.apiURL}/api/FetchExternal/${gov}`);
  }
}
