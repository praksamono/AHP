import { NgModule, Component } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
// import {TodosComponent} from './components/todos/todos.component';
// import {AlternativesComponent} from './components/alternatives/alternatives.component';
import {AboutComponent} from './route-components/about/about.component';
import {HomeComponent} from './route-components/home/home.component';
import { GoalsListComponent } from './components/goals-list/goals-list.component';


const routes: Routes = [
  {path: '', component: HomeComponent},
  {path: 'about', component: AboutComponent},
  {path: 'goals', component: GoalsListComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
