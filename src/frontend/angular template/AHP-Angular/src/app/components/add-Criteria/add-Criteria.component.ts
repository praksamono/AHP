import { Component, OnInit, EventEmitter, Output} from '@angular/core';
import {FormBuilder, FormGroup, FormControl} from '@angular/forms';
import {CriteriaService} from '../../common/services/Criteria.service';//Criterias are criteria
import {Router} from '@angular/router';
import {Criteria} from '../../common/models/Criteria';

@Component({
  selector: 'app-add-Criteria',
  templateUrl: './add-Criteria.component.html',
  styleUrls: ['./add-Criteria.component.css']
})
export class AddCriteriaComponent implements OnInit {
  @Output() dodajCriteria:EventEmitter<Criteria> = new EventEmitter();

  rForm:FormGroup;
  lstCriteria:Criteria[];



  constructor(private fb: FormBuilder, public criteriaservice: CriteriaService) {}

  ngOnInit() {
    this.addCriteria();
    this.criteriaservice.getCriteria()
    .subscribe(
      data=>{
        this.lstCriteria=data;
      }
    );
  }

   addCriteria(){
     this.rForm=this.fb.group({
       CriteriumName:['']
     })
   }

  onSubmit(){
    this.criteriaservice.addCriteria(this.rForm.value).subscribe(res =>{
      console.log('Criteria Added!');
    })
  }
    /*const Criteria={
      title:this.title,
      completed:false
    }
    this.addCriteria.emit(Criteria);
  }*/

}
