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
        this.getState();
        this.criteriaService.getCriteria(this.goalId).subscribe(
            res => {
                // console.log(res);
                res.sort((a, b) => (a.order > b.order) ? 1 : -1);
                for (let criterion of res) {
                    // console.log(criterion);
                    this.criteria.push(criterion.criteriumName);
                    this.criteriaIds.push(criterion.id);
                }

                this.alternativeService.getAlternatives(this.goalId).subscribe(
                    res => {
                        res.sort((a, b) => (a.order > b.order) ? 1 : -1);
                        for (let alternative of res) {
                            this.alternatives.push(alternative.alternativeName);
                        }
                        this.makePairs(this.criteria);
                        this.values = Array(this.pairs.length).fill(0);
                    });
                });

                this.nextCriterion();
                // console.log(this.criteriaIds);
            }

            makePairs(elems: string[]) {
                // console.log(elems);
                // console.log(elems.length);
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
                this.index++;
                this.nextCriterion();
                this.values = Array(this.pairs.length).fill(0);
            }

            nextCriterion() {
                if (this.index !== this.criteria.length + 1) {
                    let currentCriterion = this.criteria[this.index - 1];
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
                    console.log(this.values);
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
