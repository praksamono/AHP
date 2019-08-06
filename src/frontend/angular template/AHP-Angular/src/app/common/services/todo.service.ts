import { Injectable } from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import {Todo} from '../../common/models/Todo';
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
export class TodoService {

  CriteriaUrl:string='http://localhost:7867/api/criteria';
  todosLimit='?_limit=0';
  byid='c52eeff9-9ce4-49a8-b40d-5f897b7fd382';


  constructor(private http:HttpClient) { }
  //get criteria
    getCriteria() : Observable<Todo[]>{
      return this.http.get<Todo[]>(`${this.CriteriaUrl}/${this.byid}`);
    }
  //toggle completed
  toggleCompleted(todo:Todo):Observable<any>{

    const url=`${this.CriteriaUrl}/${todo.id}`;
    return this.http.put(url,todo,httpOptions);
  }
  //DELETE
  deleteCriteria(todo:Todo):Observable<Todo>{

    const url=`${this.CriteriaUrl}/${todo.id}`;
    return this.http.delete<Todo>(url,httpOptions);
  }
  //POST

  addCriteria(todo:Todo):Observable<Todo>{
    return this.http.post<Todo>(`${this.CriteriaUrl}/${this.byid}`,todo,httpOptions)
  }



}
