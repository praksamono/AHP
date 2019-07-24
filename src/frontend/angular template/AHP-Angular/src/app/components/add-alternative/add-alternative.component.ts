import { Component, OnInit, EventEmitter, Output } from '@angular/core';

@Component({
  selector: 'app-add-alternative',
  templateUrl: './add-alternative.component.html',
  styleUrls: ['./add-alternative.component.css']
})
export class AddAlternativeComponent implements OnInit {

  @Output() addAlternative:EventEmitter<any>=new EventEmitter();

  AlternativeName:string;
  constructor() { }

  ngOnInit() {
  }
  
  onSubmit(){
    const alternative={
      AlternativeName:this.AlternativeName,
      completed:false
    }
    this.addAlternative.emit(alternative);
  }

}
