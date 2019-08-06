import { Component, OnInit } from '@angular/core';

@Component({
    selector: 'app-results',
    templateUrl: './results.component.html',
    styleUrls: ['./results.component.css']
})
export class ResultsComponent implements OnInit {
    // mock data for testing
    results = [
        {
            "name": "Alt3",
            "priority": 0.6
        },
        {
            "name": "Alt1",
            "priority": 0.3
        },
        {
            "name": "Alt2",
            "priority": 0.1
        },
    ];

    constructor() { }

    ngOnInit() {
    }

}
