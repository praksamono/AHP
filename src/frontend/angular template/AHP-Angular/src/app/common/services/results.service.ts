import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import {Observable, throwError} from 'rxjs';
import { retry, catchError } from 'rxjs/operators';
import {Alternative} from '../models/alternative';

const httpOptions = {
  headers: new HttpHeaders({
      'Content-Type': 'application/json'
  })
}

@Injectable({
  providedIn: 'root'
})
export class ResultsService {

  baseurl: string = 'http://localhost:7867/api' ;
  path= '/results';
  byid='c52eeff9-9ce4-49a8-b40d-5f897b7fd382';

  constructor(private http: HttpClient) {}

  errorHandle(error)
  {
    let errorMessage = '';
    if (error.error instanceof ErrorEvent) {
        // Get client-side error
        errorMessage = error.error.message;
    } else {
        // Get server-side error
        errorMessage = `Error Code: ${error.status}\nMessage: ${error.message}`;
    }
    console.log(errorMessage);
    return throwError(errorMessage);
}
//GET
getAlternatives() : Observable<Alternative[]>{
  return this.http.get<Alternative[]>(`${this.baseurl}${this.path}/${this.byid}`);
}

}
