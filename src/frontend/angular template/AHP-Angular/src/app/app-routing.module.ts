import { NgModule, Component } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
// import {TodosComponent} from './components/todos/todos.component';
// import {AlternativesComponent} from './components/alternatives/alternatives.component';
import {AboutComponent} from './route-components/about/about.component';
import {HomeComponent} from './route-components/home/home.component';


const routes: Routes = [
  {path: '', component: HomeComponent},
  {path: 'about', component: AboutComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
