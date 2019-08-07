import { NgModule, Component } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import {AboutComponent} from './route-components/about/about.component';
import {HomeComponent} from './route-components/home/home.component';
<<<<<<< HEAD
import { GoalsListComponent } from './components/goals-list/goals-list.component';


const routes: Routes = [
  {path: '', component: HomeComponent},
  {path: 'about', component: AboutComponent},
  {path: 'goals', component: GoalsListComponent}
=======
import {CriteriaComponent} from './route-components/criteria/criteria.component';
import {AlternativesInterfaceComponent} from './route-components/alternatives-interface/alternatives-interface.component';
import {ComparisonsComponent} from './route-components/comparisons/comparisons.component';
import {ResultsInterfaceComponent} from './route-components/results-interface/results-interface.component';

const routes: Routes = [
  {path: '', component: HomeComponent},
  {path: 'criteria', component : CriteriaComponent},
  {path: 'alternatives', component : AlternativesInterfaceComponent},
  {path: 'comparisons/:criterion-name', component: ComparisonsComponent},
  {path: 'results', component: ResultsInterfaceComponent},
  {path: 'about', component: AboutComponent}
>>>>>>> 91a97d9a6b7b8733b1c757ddae8b1a6dffe30139
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
