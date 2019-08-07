import { Component, OnInit } from '@angular/core';
import { GoalService } from 'src/app/common/services/goal.service';
import { Goal } from '../../common/models/goal'

@Component({
  selector: 'app-goals-list',
  templateUrl: './goals-list.component.html',
  styleUrls: ['./goals-list.component.css']
})
export class GoalsListComponent implements OnInit {
  goals : Goal[];
  constructor(public goalService: GoalService) { }

  ngOnInit() {
  }

  

  getAllGoals(){
    // this.rForm=this.fb.group({
    //     goalname :['']
    // })
    this.goalService.GetAllGoals().subscribe( Response => this.goals = Response);
    console.log(this.goals);
  }

}
