import { Injectable } from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import {Alternative} from '../../common/models/alternative';
import {Observable} from 'rxjs';

const httpOptions= {
  headers:new HttpHeaders({
    'Content-Type': 'application/json'
  })
}

@Injectable({
  providedIn: 'root'
})
export class AlternativeService {

  Url: string='https://jsonplaceholder.typicode.com/todos';
  Limit='?_limit=0';


  constructor(private http: HttpClient) { }
  //get
    getAlternatives() : Observable<Alternative[]> {
      return this.http.get<Alternative[]>(`${this.Url}${this.Limit}`);
    }
  //toggle completed
  toggleCompleted(alternative: Alternative): Observable<any>{

    const url = `${this.Url}/${alternative.AlternativeId}`;
    return this.http.put(url,alternative,httpOptions);
  }
  //delete
  deleteAlternative(alternative: Alternative): Observable<Alternative> {

    const url = `${this.Url}/${alternative.AlternativeId}`;
    return this.http.delete<Alternative>(url, httpOptions);
  }
  //Add

  addAlternative(alternative: Alternative): Observable<Alternative> {
    return this.http.post<Alternative>(this.Url, alternative, httpOptions);
  }
}
