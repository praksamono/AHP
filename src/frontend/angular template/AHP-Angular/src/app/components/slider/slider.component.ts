import { Component, OnInit } from '@angular/core';
import { CriteriaService } from '../../common/services/Criteria.service';
import { AlternativeService } from '../../common/services/alternative.service';

@Component({
    selector: 'app-slider',
    templateUrl: './slider.component.html',
    styleUrls: ['./slider.component.css']
})
export class SliderComponent implements OnInit {
    index: number;
    nextRoute: string;
    criteria: string[];
    alternatives: string[];
    pairs: string[][];
    message: string = "Set criteria priority";

    constructor(
        private criteriaService: CriteriaService,
        private alternativeService: AlternativeService) {
        this.index = 0;
        this.nextRoute = '';
        this.criteria = [];
        this.alternatives = [];
        this.pairs = [];
    }

    ngOnInit() {
        this.criteriaService.getCriteria().subscribe(
            res => {
            for (let criterion of res) {
                this.criteria.push(criterion.CriteriumName);
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
        this.index += 1;
        this.nextCriterion();
    }

    nextCriterion() {
        if (this.index !== this.criteria.length) {
            let currentCriterion = this.criteria[this.index];
            this.nextRoute = `/comparisons/${currentCriterion}`;
            this.index += 1;
        } else {
            this.nextRoute = '/results'
        }
    }

    setMessage() {
        this.message = this.criteria[this.index];
    }

}
