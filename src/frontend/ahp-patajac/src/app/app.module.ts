import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { GoalComponent } from './goal/goal.component';
import { CriteriaComponent } from './criteria/criteria.component';
import { AlternativesComponent } from './alternatives/alternatives.component';
import { ComparisonsComponent } from './comparisons/comparisons.component';
import { ResultsComponent } from './results/results.component';

@NgModule({
  declarations: [
    AppComponent,
    GoalComponent,
    CriteriaComponent,
    AlternativesComponent,
    ComparisonsComponent,
    ResultsComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
