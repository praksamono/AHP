import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {HttpClientModule} from '@angular/common/http';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';


import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CriteriasComponent } from './components/Criterias/Criterias.component';
import { CriteriaItemComponent } from './components/Criteria-item/Criteria-item.component';
import { HeaderComponent } from './components/layout/header/header.component';
import { AddCriteriaComponent } from './components/add-Criteria/add-Criteria.component';
import { AboutComponent } from './route-components/about/about.component';
import { AddAlternativeComponent } from './components/add-alternative/add-alternative.component';
import { AlternativeItemComponent } from './components/alternative-item/alternative-item.component';
import { AlternativesComponent } from './components/alternatives/alternatives.component';
import { HomeComponent } from './route-components/home/home.component';
import { LegendComponent } from './components/legend/legend.component';
import { SliderComponent } from './components/slider/slider.component';
import { ResultsComponent } from './components/results/results.component';
import { SlideralternativeComponent } from './components/slideralternative/slideralternative.component';
import { AddGoalComponent } from './components/add-goal/add-goal.component';
import {GoalService} from './common/services/goal.service';
import {CriteriaService} from './common/services/Criteria.service';
import {AlternativeService} from './common/services/alternative.service';
import {ComparisonsService} from './common/services/comparisons.service';
import {ResultsService} from './common/services/results.service';
import { CriteriaComponent } from './route-components/criteria/criteria.component';
import { ComparisonsComponent } from './route-components/comparisons/comparisons.component';
import { AlternativesInterfaceComponent } from './route-components/alternatives-interface/alternatives-interface.component';
import { ResultsInterfaceComponent } from './route-components/results-interface/results-interface.component';

@NgModule({
  declarations: [
    AppComponent,
    CriteriasComponent,
    CriteriaItemComponent,
    HeaderComponent,
    AddCriteriaComponent,
    AboutComponent,
    AddAlternativeComponent,
    AlternativeItemComponent,
    AlternativesComponent,
    HomeComponent,
    LegendComponent,
    SliderComponent,
    ResultsComponent,
    SlideralternativeComponent,
    AddGoalComponent,
    CriteriaComponent,
    ComparisonsComponent,
    AlternativesInterfaceComponent,
    ResultsInterfaceComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    BrowserAnimationsModule
  ],
  providers: [GoalService, CriteriaService, AlternativeService,ComparisonsService,ResultsService],
  bootstrap: [AppComponent]
})
export class AppModule { }
