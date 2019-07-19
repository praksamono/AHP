import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  ime:string ="Tašula";
  constructor(){
    this.changeName("Jovan");
  }
  changeName(name:string):void{
    this.ime=name;
  }
}
