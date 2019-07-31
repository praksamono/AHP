import { Component, OnInit, NgZone} from '@angular/core';
import {FormBuilder, FormGroup, Validators, FormControl} from '@angular/forms';
import {goalinputValidator} from '../../validators/goalvalidator';
import {HttpClient} from '@angular/common/http';
import {GoalService} from '../../common/services/goal.service';
import {Router} from '@angular/router';


@Component({
  selector: 'app-add-goal',
  templateUrl: './add-goal.component.html',
  styleUrls: ['./add-goal.component.css']
})
export class AddGoalComponent {

  url = `http://localhost:7867/`;
  rForm: FormGroup;
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
    this.goalservice.CreateGoal(this.rForm.value).subscribe(res => {
      console.log('Goal Added');
      this.ngZone.run(()=> this.router.navigateByUrl('/goal-list'))
    })
  }

  getGoal() {
    return this.rForm.get('goal');
  }
}
