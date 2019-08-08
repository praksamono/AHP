import { Component, OnInit, NgZone} from '@angular/core';
import {FormBuilder, FormGroup, Validators, FormControl} from '@angular/forms';
import {goalinputValidator} from '../../validators/goalvalidator';
import {GoalService} from '../../common/services/goal.service';
import {Router} from '@angular/router';
import { Goal } from '../../common/models/goal';
import { Ng4LoadingSpinnerService } from 'ng4-loading-spinner';


@Component({
    selector: 'app-add-goal',
    templateUrl: './add-goal.component.html',
    styleUrls: ['./add-goal.component.css']
})
export class AddGoalComponent implements OnInit {

    // change if needed
    url = `http://ahpsimulator.azurewebsites.net/`;
    goal: Goal;


    ngOnInit() {
        this.goal = new Goal();
    }

    constructor(
        private spinnerService: Ng4LoadingSpinnerService,
        private router: Router,
        public goalService: GoalService) {
          this.goal=new Goal;

    }

    addGoal(){

        console.log(this.goal.goalname);
        this.spinnerService.show();
        this.goalService.CreateGoal(this.goal).subscribe(res =>
        {

          console.log(res);
          this.spinnerService.hide();
          this.router.navigateByUrl('/criteria', {state: { goalId: res.id}});
        }

        );

    }
    // createFormGroup(){
    //     return new FormGroup({
    //         goal: new FormControl('', [Validators.required, goalinputValidator, Validators.minLength(2), Validators.maxLength(25)])
    //     });
    // }
    // submitForm(){
    //     this.goalservice.CreateGoal(this.rForm.value).subscribe(res => {
    //         console.log('Goal Added');
    //         this.GoalIdAfterPost=res.id;
    //         console.log(this.GoalIdAfterPost);
    //     })
    // }

    // getGoal() {
    //     return this.rForm.get('goal');
    // }

    // getIfErrorIsTriggered(Errorname: string) : boolean {
    //     const Control  = this.getGoal();
    //     if(!Control){
    //         return false;
    //     }
    //     if((Control.dirty || Control.touched) && Control.invalid && Control.errors && Control.errors[Errorname]) {
    //         return true;
    //     }
    //     return false;
    // }
}
