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
    // change if needed
    AlternativeUrl: string='http://localhost:5000/api/alternatives';
    byid="c52eeff9-9ce4-49a8-b40d-5f897b7fd382";


    constructor(private http: HttpClient) { }
    //get
    getAlternatives() : Observable<Alternative[]> {
        return this.http.get<Alternative[]>(`${this.AlternativeUrl}/${this.byid}`);
    }
    //toggle completed
    toggleCompleted(alternative: Alternative): Observable<any>{

        const url = `${this.AlternativeUrl}/${alternative.AlternativeId}`;
        return this.http.put(url,alternative,httpOptions);
    }
    //delete
    deleteAlternative(alternative: Alternative): Observable<Alternative> {

        const url = `${this.AlternativeUrl}/${alternative.AlternativeId}`;
        return this.http.delete<Alternative>(url, httpOptions);
    }
    //Add

    addAlternative(alternative: Alternative[]): Observable<Alternative[]> {
        return this.http.post<Alternative[]>(this.AlternativeUrl, alternative, httpOptions);
    }
}
