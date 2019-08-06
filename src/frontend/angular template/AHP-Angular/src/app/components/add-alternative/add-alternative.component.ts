import { Component, OnInit, EventEmitter, Output } from '@angular/core';
import {FormBuilder, FormGroup, FormControl} from '@angular/forms';
import {AlternativeService} from '../../common/services/alternative.service';//todos are criteria
import {Router} from '@angular/router';
import {Alternative} from '../../common/models/alternative';

@Component({
  selector: 'app-add-alternative',
  templateUrl: './add-alternative.component.html',
  styleUrls: ['./add-alternative.component.css']
})
export class AddAlternativeComponent implements OnInit {

  @Output() addAlternative:EventEmitter<any>=new EventEmitter();

  rForm:FormGroup;
  lstAlternatives:Alternative[];
  AlternativeName:string;
  constructor(private fb: FormBuilder, public alternativeservice: AlternativeService) { }

  ngOnInit() {
    this.alternativeservice.getAlternatives()
    .subscribe(
      data=>{
        this.lstAlternatives=data;
      }
    );
  }

  onSubmit(){
    const alternative={
      AlternativeName:this.AlternativeName,
      completed:false
    }
    this.addAlternative.emit(alternative);
  }

}
