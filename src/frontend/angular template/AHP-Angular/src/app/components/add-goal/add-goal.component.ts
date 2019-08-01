import { Component, OnInit, NgZone} from '@angular/core';
import {FormBuilder, FormGroup, Validators, FormControl} from '@angular/forms';
import {goalinputValidator} from '../../validators/goalvalidator';
import {GoalService} from '../../common/services/goal.service';
import {Router} from '@angular/router';


@Component({
  selector: 'app-add-goal',
  templateUrl: './add-goal.component.html',
  styleUrls: ['./add-goal.component.css']
})
export class AddGoalComponent implements OnInit {

  url = `http://localhost:7867/`;
  rForm: FormGroup;
  GoalArr : any=[];

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
      goalname: new FormControl('', [Validators.required, goalinputValidator, Validators.minLength(2), Validators.maxLength(25)])
    });
  }
  submitForm(){
    this.goalservice.CreateGoal(this.rForm.value).subscribe(res => {
      console.log('Goal Added');
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
