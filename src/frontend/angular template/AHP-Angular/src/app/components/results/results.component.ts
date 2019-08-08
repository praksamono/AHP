import { Component, OnInit } from '@angular/core';
// import { Router } from '@angular/router';

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
    topResult: Alternative;

    constructor(private resultsService: ResultsService) {
        this.results = [new Alternative()];
    }

    ngOnInit() {
        this.getState();
        // console.log(this.results);

    }

    getState() {
        let state = window.history.state;
        this.goalId = state.goalId;
        this.getResults();
    }

    getResults() {
        this.resultsService.getAlternatives(this.goalId).subscribe(
            res => {
                res.sort((a, b) => (a.GlobalPriority > b.GlobalPriority) ? 1 : -1);
                // TODO: skontaj zasto je this.results undefined nakon ove metode
                this.results = res;
                this.topResult = this.results[0];
                document.getElementById('top-result').innerHTML = this.topResult.alternativeName;
            });
    }



}
