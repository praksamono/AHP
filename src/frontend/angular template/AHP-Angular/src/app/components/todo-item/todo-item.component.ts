import { Component, OnInit, Input,EventEmitter,Output} from '@angular/core';
import {Todo} from '../../common/models/Todo';
import {TodoService} from '../../common/services/todo.service';


@Component({
  selector: 'app-todo-item',
  templateUrl: './todo-item.component.html',
  styleUrls: ['./todo-item.component.css']
})
export class TodoItemComponent implements OnInit {

  @Input() todo : Todo;
  @Output() deleteTodo: EventEmitter<Todo>= new EventEmitter();
  constructor(private todoService:TodoService ) { }

  ngOnInit() {
  }
  //Setting dynamic classes
  setClasses(){
    let classes={
      todo:true,
      'is-complete':this.todo.completed
    }
    return classes;
  }
  onToggle(todo){
    //toggle na stranici
    todo.completed=!todo.completed;
    //toggle na serveru
    this.todoService.toggleCompleted(todo).subscribe(todo=>
      console.log(todo));
  }
  onDelete(todo){
  this.deleteTodo.emit(todo);
  }
}
