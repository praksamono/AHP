import { Component, OnInit } from '@angular/core';
// import {FormBuilder, FormGroup, FormControl} from '@angular/forms';
import {AlternativeService} from '../../common/services/alternative.service';//Alternatives are criteria
// import {Router} from '@angular/router';
import {Alternative} from '../../common/models/alternative';

@Component({
    selector: 'app-add-alternative',
    templateUrl: './add-alternative.component.html',
    styleUrls: ['./add-alternative.component.css']
})
export class AddAlternativeComponent implements OnInit {

    // @Output() addAlternative:EventEmitter<any>=new EventEmitter();
    //
    // rForm:FormGroup;
    // lstAlternatives:Alternative[];
    // AlternativeName:string;
    alternatives: Alternative[];
    constructor(
        // private fb: FormBuilder,
        public alternativeService: AlternativeService) {
            this.alternatives = [];
        }

        ngOnInit() {
            //   this.alternativeService.getAlternatives()
            // .subscribe(
            //   data=>{
            //     this.lstAlternatives=data;
            //   }
            // );
            this.addInput();
            this.addInput();
        }

        // onSubmit(){
        //   const alternative={
        //     AlternativeName:this.AlternativeName,
        //     completed:false
        //   }
        //   this.addAlternative.emit(alternative);
        // }

        addInput(): void {
            this.alternatives.push(new Alternative);
        }

        saveInputs() {
            let inputAlternative: Alternative[] = [];
            for (let alternative of this.alternatives) {
                inputAlternative.push(new Alternative(alternative.alternativeName));
            }
            this.alternativeService.addAlternative(inputAlternative).subscribe(res => this.alternatives = res);
            // DEBUG:
            // console.log(this.alternatives);
        }

    }
