import { Component, OnInit } from '@angular/core';
import { Alternative } from '../../common/models/alternative';
import { ResultsService } from '../../common/services/results.service';

@Component({
    selector: 'app-results',
    templateUrl: './results.component.html',
    styleUrls: ['./results.component.css']
})
export class ResultsComponent implements OnInit {
    results: Alternative[];

    constructor(
        private resultsService: ResultsService
    ) {
    this.resultsService.getAlternatives().subscribe(res => this.results = res);
    }

    ngOnInit() {
    }



}
