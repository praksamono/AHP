import { Component, OnInit, NgZone} from '@angular/core';
import {FormBuilder, FormGroup, Validators, FormControl} from '@angular/forms';
import {goalinputValidator} from '../../validators/goalvalidator';
import {GoalService} from '../../common/services/goal.service';
import {Router} from '@angular/router';
import {Goal} from '../../common/models/goal';


@Component({
  selector: 'app-add-goal',
  templateUrl: './add-goal.component.html',
  styleUrls: ['./add-goal.component.css']
})
export class AddGoalComponent implements OnInit {

  url = `http://localhost:7867/`;
  rForm: FormGroup;
  GoalArr : any=[];
  GoalIdAfterPost:number;

  ngOnInit() {
    this.addGoal()
  }

  constructor(private fb: FormBuilder, private ngZone: NgZone, private router: Router, public goalservice: GoalService) {
    this.rForm = this.createFormGroup();
  }

  addGoal(){
    this.rForm=this.fb.group({
      goalname :['']
    })
  }
  createFormGroup(){
    return new FormGroup({
      goal: new FormControl('', [Validators.required, goalinputValidator, Validators.minLength(2), Validators.maxLength(25)])
    });
  }
  submitForm(){
    this.goalservice.CreateGoal(this.rForm.value).subscribe((goal: Goal) => {
      console.log('Goal Added');
      this.GoalIdAfterPost = goal.id;
      console.log(this.GoalIdAfterPost);
    })
  }

  getGoal() {
    return this.rForm.get('goal');
  }

  getIfErrorIsTriggered(Errorname: string) : boolean {
    const Control  = this.getGoal();
    if(!Control){
      return false;
    }
    if((Control.dirty || Control.touched) && Control.invalid && Control.errors && Control.errors[Errorname]) {
      return true;
    }
    return false;
  }
}
