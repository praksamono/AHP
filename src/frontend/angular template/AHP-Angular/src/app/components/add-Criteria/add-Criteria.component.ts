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
