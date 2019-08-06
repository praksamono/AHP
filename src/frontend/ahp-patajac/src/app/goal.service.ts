import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';

import { Goal } from './goal';

@Injectable({
  providedIn: 'root'
})
export class GoalService {

  constructor() { }

  addGoal(goal: Goal): Observable<Goal> {
      // TODO: add goal to db
      return of(goal);
  }

  // getGoalID(): Observable<number> {
  //     // TODO: implement
  // }
}
