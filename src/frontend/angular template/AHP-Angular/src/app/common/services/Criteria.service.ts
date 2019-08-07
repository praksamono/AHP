import { Injectable } from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import {Criteria} from '../models/Criteria';
import {Observable,throwError} from 'rxjs';
import { retry, catchError } from 'rxjs/operators';
import {AddGoalComponent} from '../../components/add-goal/add-goal.component';

const httpOptions = {
    headers: new HttpHeaders({
        'Content-Type': 'application/json'
    })
}

@Injectable({
    providedIn: 'root'
})
export class CriteriaService {

  baseurl:string='http://localhost:7867/api/criteria';
  byid='c52eeff9-9ce4-49a8-b40d-5f897b7fd382';
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
        return this.http.get<Criteria[]>(`${this.baseurl}/${this.byid}`);
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

    addCriteria(Criteria:Criteria[]):Observable<Criteria[]>{
        return this.http.post<Criteria[]>(`${this.baseurl}/${this.byid}`,Criteria,httpOptions)
    }

    updateCriteria(/*goalid:Number,*/values:Number[]):Observable<any>
      {
      return this.http.put<any>(`${this.baseurl}/${this.byid}`, values, httpOptions)
      .pipe(
          retry(1),
          catchError(this.errorHandle));
      }
  //toggle completed
  /*toggleCompleted(Criteria:Criteria):Observable<any>{

    const url=`${this.CriteriaUrl}/${Criteria.id}`;
    return this.http.put(url,Criteria,httpOptions);
  }
  //DELETE
  deleteCriteria(Criteria:Criteria):Observable<Criteria>{

    const url=`${this.CriteriaUrl}/${Criteria.id}`;
    return this.http.delete<Criteria>(url,httpOptions);
  }
  //POST

  addCriteria(Criteria:Criteria[]):Observable<Criteria[]>{
    return this.http.post<Criteria[]>(`${this.CriteriaUrl}/${this.byid}`,Criteria,httpOptions);
  }
*/


}
