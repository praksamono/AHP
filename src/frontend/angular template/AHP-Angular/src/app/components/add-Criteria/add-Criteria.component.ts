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

    Criterias: Criteria[];
    goalId:number;
    constructor(private criteriaService: CriteriaService) {
        this.Criterias = [];
    }
    ngOnInit() {
        // this.criteriaService.getCriteria().subscribe(Criterias =>
        //   {
        //     this.Criterias=Criterias;
        //   });
        this.getState();
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
        let nonEmptyCriteria = this.Criterias.filter(criterion => criterion.CriteriumName.length);
        for (let criterion of nonEmptyCriteria) {
            inputCriteria.push(new Criteria(criterion.CriteriumName));
        }
        this.criteriaService.addCriteria(inputCriteria).subscribe(res => this.Criterias = res);
        // DEBUG:
        // console.log(this.Criterias);
    }

    getState(){
      let state = window.history.state;
      this.goalId = state.goalId;
      console.log(this.goalId);
    }

}
