import { NgModule, Component } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import {AboutComponent} from './route-components/about/about.component';
import {HomeComponent} from './route-components/home/home.component';
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
];

@NgModule({
    // scrolls to top of the page
    imports: [RouterModule.forRoot(routes, {scrollPositionRestoration: 'enabled'})],
    exports: [RouterModule]
})
export class AppRoutingModule { }
