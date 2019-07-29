import { Component, OnInit } from '@angular/core';
import {FormBuilder, FormGroup, Validators, FormControl} from '@angular/forms';
import {goalinputValidator} from '../../validators/goalvalidator';
import {HttpClient} from '@angular/common/http';

@Component({
  selector: 'app-add-goal',
  templateUrl: './add-goal.component.html',
  styleUrls: ['./add-goal.component.css']
})
export class AddGoalComponent {

  rForm:FormGroup;
  constructor(private fb: FormBuilder) {
    this.rForm = this.createFormGroup();
  }

  createFormGroup(){
    return new FormGroup({
      goal: new FormControl('', [Validators.required, goalinputValidator, Validators.minLength(2), Validators.maxLength(25)])
    });
  }
  onSubmit() {}

  getGoal() {
    return this.rForm.get('goal');
  }
}
