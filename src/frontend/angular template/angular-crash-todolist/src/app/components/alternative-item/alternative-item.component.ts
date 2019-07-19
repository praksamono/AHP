import { Component, OnInit,Input,EventEmitter,Output} from '@angular/core';
import {Alternative} from '../models/alternative';
import {AlternativeService} from '../../services/alternative.service';

@Component({
  selector: 'app-alternative-item',
  templateUrl: './alternative-item.component.html',
  styleUrls: ['./alternative-item.component.css']
})
export class AlternativeItemComponent implements OnInit {

  @Input() alternative: Alternative;
  @Output() deleteAlternative : EventEmitter<Alternative> = new EventEmitter();
     
  constructor(private alternativeService:AlternativeService ) { }

  ngOnInit() {
  }
    //Setting dynamic classes
  setClasses(){
    let classes={
      alternative:true,
      'is-complete':this.alternative.completed
    }
    return classes;
  }
  onToggle(alternative){
    //toggle na stranici
    alternative.completed=!alternative.completed;
    //toggle na serveru
    this.alternativeService.toggleCompleted(alternative).subscribe(alternative=>
      console.log(alternative));
  }
  onDelete(alternative){
  this.deleteAlternative.emit(alternative);
  }
}

