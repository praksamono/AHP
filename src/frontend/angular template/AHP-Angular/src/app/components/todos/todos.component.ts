import { Component, OnInit } from '@angular/core';
import{ TodoService} from '../../common/services/todo.service';
import {Todo} from '../../common/models/Todo';
import { Observable } from 'rxjs';


@Component({
  selector: 'app-todos',
  templateUrl: './todos.component.html',
  styleUrls: ['./todos.component.css']
})
export class TodosComponent implements OnInit {

  todos:Todo[];

  constructor(private todoService:TodoService) {

   }

  ngOnInit() {
      this.todoService.getTodos().subscribe(todos =>
        {
          this.todos=todos;
        });
  }
  deleteTodo(todo:Todo){
    this.todos=this.todos.filter(t=>t.id !== todo.id);//deletam taj objekt koji ima taj id sa UI-a
    this.todoService.deleteTodo(todo).subscribe();//deleteam sa servera
  }
  addTodo(todo:Todo) {
    this.todoService.addTodo(todo).subscribe(todo => {
      this.todos.push(todo);
      console.log(this.todos);
    });
  }

}
