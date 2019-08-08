import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { Alternative } from '../../common/models/alternative';
import { ResultsService } from '../../common/services/results.service';

@Component({
    selector: 'app-results',
    templateUrl: './results.component.html',
    styleUrls: ['./results.component.css']
})
export class ResultsComponent implements OnInit {
    goalId: number;
    results: Alternative[];

    constructor(private resultsService: ResultsService) { }

    ngOnInit() {
        this.getState();
        this.getResults();
    }

    getState() {
        let state = window.history.state;
        this.goalId = state.goalId;
    }

    getResults() {
        this.resultsService.getAlternatives(this.goalId).subscribe(res => this.results = res);
    }



}
