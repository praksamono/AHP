import { Component, OnInit } from '@angular/core';
import {AlternativeService} from '../../common/services/alternative.service';
import {Alternative} from '../../common/models/alternative';
import {Observable} from 'rxjs';


@Component({
  selector: 'app-alternatives',
  templateUrl: './alternatives.component.html',
  styleUrls: ['./alternatives.component.css']
})
export class AlternativesComponent implements OnInit {

  alternatives:Alternative[];

  constructor(private alternativeService:AlternativeService) { }

  ngOnInit() {
    this.alternativeService.getAlternatives().subscribe(alternatives=>
      {
        this.alternatives=alternatives;
      });
  }
  // deleteAlternative(alternative:Alternative){
  //   this.alternatives=this.alternatives.filter(a=>a.AlternativeId !== alternative.AlternativeId);
  //   this.alternativeService.deleteAlternative(alternative).subscribe();//deleteam sa servera
  // }
  // addAlternative(alternative:Alternative){
  //   this.alternativeService.addAlternative(alternative).subscribe(alternative => {
  //     this.alternatives.push(alternative);
  //     console.log(this.alternatives);
  //   });
  // }
}
