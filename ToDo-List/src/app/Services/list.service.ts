import { HttpClient, HttpClientModule } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ListService {

  constructor(private http: HttpClient) { 

  }

  public list(): Observable<any[]>{
    return this.http.get<any[]>('https://localhost:7283/api/tasks',{
      headers: {
        'Content-Type': 'application/json'
      }
    });
  }
}
