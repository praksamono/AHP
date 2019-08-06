import { Component, OnInit } from '@angular/core';

import { Goal } from '../goal';
import { GoalService } from '../goal.service';

@Component({
    selector: 'app-goal',
    templateUrl: './goal.component.html',
    styleUrls: ['./goal.component.css']
})
export class GoalComponent implements OnInit {
    goal: Goal;

    constructor(private goalService: GoalService) { }

    ngOnInit() {
    }

    addGoal(name: string): void {
        name = name.trim();
        if (!name) { return; }
        // TODO: add goalService
        this.goalService.addGoal({ name } as Goal)
        .subscribe(goal => this.goal = goal);
    }

}
