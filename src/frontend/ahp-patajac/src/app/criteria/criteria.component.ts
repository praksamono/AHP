import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';

import { Criterion } from '../criterion';

@Component({
    selector: 'app-criteria',
    templateUrl: './criteria.component.html',
    styleUrls: ['./criteria.component.css']
})
export class CriteriaComponent implements OnInit {
    criteria: Criterion[] = [];
    criteriaInput = new FormGroup({
        criterionInput: new FormControl(''),
    });

    constructor() { }

    ngOnInit() {
        this.addInput();
        this.addInput();
    }

    addInput(): void {
        this.criteria.push(new Criterion);
    }

    // submitCriteria() {
    //     console.log(this.criteriaInput.value);
    // }

}
