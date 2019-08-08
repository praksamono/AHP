import { Component, OnInit } from '@angular/core';
import {AlternativeService} from '../../common/services/alternative.service';
import {Router} from '@angular/router';
import {Alternative} from '../../common/models/alternative';
import { Ng4LoadingSpinnerService } from 'ng4-loading-spinner';

@Component({
    selector: 'app-add-alternative',
    templateUrl: './add-alternative.component.html',
    styleUrls: ['./add-alternative.component.css']
})
export class AddAlternativeComponent implements OnInit {


    alternatives: Alternative[];
    goalId:number;

    constructor(
      private spinnerService: Ng4LoadingSpinnerService,
      private router: Router,
      public alternativeService: AlternativeService) {
            this.alternatives = [];
        }

        ngOnInit() {

            this.getState();
            this.addInput();
            this.addInput();
        }



        addInput(): void {
            this.alternatives.push(new Alternative);
        }

        saveInputs() {

            let inputAlternative: Alternative[] = [];
            let nonEmptyAlternatives = this.alternatives.filter(alternative => alternative.alternativeName.length);
            for (let alternative of nonEmptyAlternatives) {
                inputAlternative.push(new Alternative(alternative.alternativeName));
            }
            this.spinnerService.show();
            this.alternativeService.addAlternative(inputAlternative,this.goalId).subscribe(res =>
              {

                console.log(res);
                this.spinnerService.hide();
                this.router.navigateByUrl('/comparisons/criteria', {state: { goalId: this.goalId}});
              }

              );

        }
        getState(){
          let state = window.history.state;
          this.goalId = state.goalId;
        }

    }
