import { Injectable } from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import {Criteria} from '../models/Criteria';
import {Observable,throwError} from 'rxjs';
import { retry, catchError } from 'rxjs/operators';

const httpOptions = {
    headers: new HttpHeaders({
        'Content-Type': 'application/json'
    })
}

@Injectable({
    providedIn: 'root'
})
export class CriteriaService {

    baseurl:string='http://ahpsimulator.azurewebsites.net/api/criteria';
    goalid:number;


    constructor(private http:HttpClient) {
    }
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
    //get criteria
    getCriteria() : Observable<Criteria[]>{
        return this.http.get<Criteria[]>(`${this.baseurl}/${this.goalid}`);
    }
    //toggle completed
    toggleCompleted(Criteria:Criteria):Observable<any>{

        const url=`${this.baseurl}/${Criteria.id}`;
        return this.http.put(url,Criteria,httpOptions);
    }
    //DELETE
    deleteCriteria(Criteria:Criteria):Observable<Criteria>{

        const url=`${this.baseurl}/${Criteria.id}`;
        return this.http.delete<Criteria>(url,httpOptions);
    }
    //POST

    addCriteria(Criteria:Criteria[],goalId: number):Observable<Criteria[]>{
        console.log(goalId);
        return this.http.post<Criteria[]>(`${this.baseurl}/${goalId}`,Criteria,httpOptions)
    }

    updateCriteria(values:number[],goalId: number):Observable<any>
    {
        return this.http.put<any>(`${this.baseurl}/${goalId}`, values, httpOptions)
        .pipe(
            retry(1),
            catchError(this.errorHandle));
        }

}
