import { Component, OnInit } from '@angular/core';
import { CriteriaService } from '../../common/services/Criteria.service';

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

    constructor(private criteriaService: CriteriaService) {
        this.index = 0;
        this.nextRoute = '';
        this.criteria = [];
        this.alternatives = [];
        this.pairs = [];
    }

    ngOnInit() {
        this.criteriaService.getCriteria().subscribe(res => {
            for (let criterion of res) {
                this.criteria.push(criterion.CriteriumName);
            }
        });
        this.makePairs();
        // this.nextCriterion();
    }

    makePairs() {
        for (let i = 0; i < this.criteria.length; i++) {
            for (let j = i+1; j < this.criteria.length; j++) {
                this.pairs.push([this.criteria[i], this.criteria[j]]);
            }
        }
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
        this.message = this.criteria[this.index - 1];
    }

}
