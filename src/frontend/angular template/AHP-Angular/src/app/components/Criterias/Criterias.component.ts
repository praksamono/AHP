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

    Criterias: Criteria[] = [];

    constructor(private criteriaService: CriteriaService) {

    }

    ngOnInit() {
        // this.criteriaService.getCriteria().subscribe(Criterias =>
        //   {
        //     this.Criterias=Criterias;
        //   });
        this.addInput();
        this.addInput();
    }

    addInput(): void {
        this.Criterias.push(new Criteria);
    }

    deleteCriteria(Criteria:Criteria){
        this.Criterias=this.Criterias.filter(t=>t.id !== Criteria.id);//deletam taj objekt koji ima taj id sa UI-a
        this.criteriaService.deleteCriteria(Criteria).subscribe();//deleteam sa servera
    }

    saveInputs() {
        let inputCriteria: Criteria[] = [];
        for (let criterion of this.Criterias) {
            inputCriteria.push(new Criteria(criterion.CriteriumName));
        }
        this.criteriaService.addCriteria(inputCriteria).subscribe(res => this.Criterias = res);
        // DEBUG:
        // console.log(this.Criterias);
    }

}
