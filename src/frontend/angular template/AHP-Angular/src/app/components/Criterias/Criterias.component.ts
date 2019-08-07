import { Component, OnInit } from '@angular/core';
import{ CriteriaService} from '../../common/services/Criteria.service';
import {Criteria} from '../../common/models/Criteria';
import { Observable } from 'rxjs';


@Component({
  selector: 'app-Criterias',
  templateUrl: './Criterias.component.html',
  styleUrls: ['./Criterias.component.css']
})
export class CriteriasComponent implements OnInit {

  Criterias:Criteria[];

  constructor(private CriteriaService:CriteriaService) {

   }

  ngOnInit() {
      this.CriteriaService.getCriteria().subscribe(Criterias =>
        {
          this.Criterias=Criterias;
        });
  }
  deleteCriteria(Criteria:Criteria[]){
    this.Criterias=this.Criterias.filter(t=>t.id !== Criteria.id);//deletam taj objekt koji ima taj id sa UI-a
    this.CriteriaService.deleteCriteria(Criteria).subscribe();//deleteam sa servera
  }
  addCriteria(Criteria:Criteria[]) {
    this.CriteriaService.addCriteria(Criteria).subscribe(Criteria => {
      this.Criterias.push(this.Criterias);
      console.log(this.Criterias);
    });
  }

}
