import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { CriteriaService } from '../../common/services/Criteria.service';
import { AlternativeService } from '../../common/services/alternative.service';
import { ComparisonsService } from '../../common/services/comparisons.service';

@Component({
    selector: 'app-slider',
    templateUrl: './slider.component.html',
    styleUrls: ['./slider.component.css']
})
export class SliderComponent implements OnInit {
    index: number;
    goalId: number;
    nextRoute: string;
    criteria: string[];
    criteriaIds: number[];
    alternatives: string[];
    values: number[];
    pairs: string[][];
    message: string = "Set criteria priority";

    constructor(
        private router: Router,
        private criteriaService: CriteriaService,
        private alternativeService: AlternativeService,
        private comparisonsService: ComparisonsService
    ) {
        this.index = 0;
        this.nextRoute = '';
        this.criteria = [];
        this.criteriaIds = [];
        this.alternatives = [];
        this.values = [];
        this.pairs = [];

    }

    ngOnInit() {
        this.criteriaService.getCriteria().subscribe(
            res => {
                for (let criterion of res) {
                    this.criteria.push(criterion.CriteriumName);
                    this.criteriaIds.push(criterion.id);
                }
            });

        this.alternativeService.getAlternatives().subscribe(
            res => {
                for (let alternative of res) {
                    this.alternatives.push(alternative.alternativeName);
                }
            });

        this.getState();
        this.makePairs(this.criteria);
        this.nextCriterion();
    }

    makePairs(elems: string[]) {
        this.pairs = [];
        for (let i = 0; i < elems.length; i++) {
            for (let j = i+1; j < elems.length; j++) {
                this.pairs.push([elems[i], elems[j]]);
            }
        }
    }

    next() {
        this.setMessage();
        this.makePairs(this.alternatives);
        this.post();
        this.index += 1;
        this.nextCriterion();
    }

    nextCriterion() {
        if (this.index !== this.criteria.length) {
            let currentCriterion = this.criteria[this.index];
            this.nextRoute = `/comparisons/${currentCriterion}`;
        } else {
            this.nextRoute = '/results'
        }
    }

    setMessage() {
        this.message = this.criteria[this.index];
    }

    post() {
        if (this.index === 0) {
            this.criteriaService.updateCriteria(this.values, this.goalId)
            .subscribe(() => this.router.navigateByUrl(`${this.nextRoute}`, {state: { goalId: this.goalId}})
            );
        } else {
            this.comparisonsService.AddPriority(this.criteriaIds[this.index - 1], this.values)
            .subscribe(() => this.router.navigateByUrl(`${this.nextRoute}`, {state: { goalId: this.goalId}})
            );
        }
    }

    getState() {
        let state = window.history.state;
        this.goalId = state.goalId;
    }

}
