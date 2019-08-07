import { Component, OnInit } from '@angular/core';
import { Alternative } from '../../common/models/alternative';

@Component({
    selector: 'app-results',
    templateUrl: './results.component.html',
    styleUrls: ['./results.component.css']
})
export class ResultsComponent implements OnInit {
    results: Alternative[];

    constructor() {
    // this.resultService.getResults().subscribe(res => this.results = res);
    }

    ngOnInit() {
    }



}
