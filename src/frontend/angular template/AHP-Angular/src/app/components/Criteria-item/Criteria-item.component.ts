import { Component, OnInit, Input,EventEmitter,Output} from '@angular/core';
import {Criteria} from '../../common/models/Criteria';
import {CriteriaService} from '../../common/services/Criteria.service';


@Component({
  selector: 'app-Criteria-item',
  templateUrl: './Criteria-item.component.html',
  styleUrls: ['./Criteria-item.component.css']
})
export class CriteriaItemComponent implements OnInit {

  @Input() Criteria : Criteria;
  @Output() deleteCriteria: EventEmitter<Criteria>= new EventEmitter();
  constructor(private CriteriaService:CriteriaService ) { }

  ngOnInit() {
  }
  //Setting dynamic classes
  setClasses(){
    let classes={
      Criteria:true,
      'is-complete': this.Criteria.completed
    }
    return classes;
  }
  onToggle(Criteria){
    //toggle na stranici
    Criteria.completed=!Criteria.completed;
    //toggle na serveru
    this.CriteriaService.toggleCompleted(Criteria).subscribe(Criteria=>
      console.log(Criteria));
  }
  onDelete(Criteria){
  this.deleteCriteria.emit(Criteria);
  }
}
