import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { GoalComponent } from './goal/goal.component';
import { CriteriaComponent } from './criteria/criteria.component';
import { AlternativesComponent } from './alternatives/alternatives.component';
import { ComparisonsComponent } from './comparisons/comparisons.component';
import { ResultsComponent } from './results/results.component';

const routes: Routes = [
    { path: '', redirectTo: '/goal', pathMatch: 'full' },
    { path: 'goal', component: GoalComponent },
    { path: 'criteria', component: CriteriaComponent },
    { path: 'alternatives', component: AlternativesComponent },
    { path: 'comparisons/:criterion-name', component: ComparisonsComponent },
    { path: 'results', component: ResultsComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes, {scrollPositionRestoration: 'enabled'})],
  exports: [RouterModule]
})
export class AppRoutingModule { }
