import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
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
export class ComparisonsService {

    baseurl: string = 'http://ahpsimulator.azurewebsites.net/api' ;
    path= '/criteriumalternatives';

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

    AddPriority(criteriumId: Number,values: Number[]): Observable<any> {
        return this.http.post<any>(`${this.baseurl}${this.path}/${criteriumId}`, values, httpOptions)
        .pipe(
            retry(1),
            catchError(this.errorHandle));
        }
    }
