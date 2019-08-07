import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import {Goal} from '../models/goal';
import {Observable, throwError} from 'rxjs';
import { retry, catchError } from 'rxjs/operators';


const httpOptions = {
    headers: new HttpHeaders({
        'Content-Type': 'application/json'
    })
}

@Injectable({
    providedIn: 'root'
})

export class GoalService {
    // change if needed
    baseurl: string = 'http://localhost:5000/api' ;
    goals= '/goals'
    constructor(private http: HttpClient) {}


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
    CreateGoal(goal: Goal): Observable<Goal> {
        return this.http.post<Goal>(`${this.baseurl}${this.goals}`, goal, httpOptions)
        .pipe(
            retry(1),
            catchError(this.errorHandle));
        }
        //GET id

        GetGoal(id): Observable<Goal> {
            return this.http.get<Goal>(`${this.baseurl}${this.goals}`)
            .pipe(
                retry(1),
                catchError(this.errorHandle));
            }

        }
