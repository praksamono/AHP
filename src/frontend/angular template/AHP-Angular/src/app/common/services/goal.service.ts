import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import {Goal} from '../models/goal';
import {Observable, throwError} from 'rxjs';
import { retry, catchError } from 'rxjs/operators';


@Injectable({
  providedIn: 'root'
})
export class GoalService {

  baseurl = 'http://localhost:7867' ;
  constructor(private http: HttpClient) {}

  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  };
  errorHandle(error) {
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
 //POST
 CreateGoal(data): Observable<Goal> {
  return this.http.post<Goal>(this.baseurl + '/api/goals', JSON.stringify(data), this.httpOptions)
  .pipe(
    retry(1),
    catchError(this.errorHandle));
}
//GET id

GetGoal(id): Observable<Goal> {
  return this.http.get<Goal>(this.baseurl + 'api/goals/' + id)
  .pipe(
    retry(1),
    catchError(this.errorHandle));
}

}





