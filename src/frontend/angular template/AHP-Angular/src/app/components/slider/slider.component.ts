import { Component, OnInit } from '@angular/core';
import { CriteriaService } from '../../common/services/Criteria.service';
import { AlternativeService } from '../../common/services/alternative.service';
import {ComparisonsService} from '../../common/services/comparisons.service';

@Component({
    selector: 'app-slider',
    templateUrl: './slider.component.html',
    styleUrls: ['./slider.component.css']
})
export class SliderComponent implements OnInit {
    index: number;
    nextRoute: string;
    criteria: string[];
    criteriaIds: number[];
    alternatives: string[];
    values: number[];
    pairs: string[][];
    message: string = "Set criteria priority";

    constructor(
        private criteriaService: CriteriaService,
        private alternativeService: AlternativeService,
        private comparisonService: ComparisonsService
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
        // DEBUG:
        // console.log(this.values);

        // TODO: switch to having goalId in url
        if (this.index === 0) {
            // this.criteriaService.updateCriteria(this.values).subscribe();
        } else {
            // this.comparisonsService.addComparison(this.criteriaIds[this.index - 1], this.values).subscribe();
        }
    }

}
