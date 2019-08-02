import { Component, OnInit, EventEmitter, Output} from '@angular/core';
import {FormBuilder, FormGroup, FormControl} from '@angular/forms';
import {TodoService} from '../../common/services/todo.service';//todos are criteria
import {Router} from '@angular/router';
import {Todo} from '../../common/models/Todo';

@Component({
  selector: 'app-add-todo',
  templateUrl: './add-todo.component.html',
  styleUrls: ['./add-todo.component.css']
})
export class AddTodoComponent implements OnInit {
  @Output() addTodo:EventEmitter<any> = new EventEmitter();

  rForm:FormGroup;
  lstCriteria:Todo[];



  constructor(private fb: FormBuilder, public criteriaservice: TodoService) {}

  ngOnInit() {
    this.criteriaservice.getCriteria()
    .subscribe(
      data=>{
        this.lstCriteria=data;
      }
    );
  }

   addCriteria(){
     this.rForm=this.fb.group({
       title:['']
     })
   }



  onSubmit(){
    this.criteriaservice.addCriteria(this.rForm.value).subscribe(res =>{
      console.log('Criteria Added!');
    })
  }
    /*const todo={
      title:this.title,
      completed:false
    }
    this.addTodo.emit(todo);
  }*/

}
