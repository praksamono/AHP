import { Component, OnInit } from '@angular/core';

@Component({
    selector: 'app-comparisons',
    templateUrl: './comparisons.component.html',
    styleUrls: ['./comparisons.component.css']
})
export class ComparisonsComponent implements OnInit {
    // mock data for testing
    index = 0;
    nextRoute: string = '';
    criteria = ["one", "two", "three"];
    pairs: string[][];

    message: string = "Set criteria priority";

    constructor() {
        this.pairs = [];
    }

    ngOnInit() {
        this.makePairs();
        this.nextCriterion();
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
