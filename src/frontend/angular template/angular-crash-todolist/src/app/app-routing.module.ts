import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import {TodosComponent} from './components/todos/todos.component';
import {AlternativesComponent} from './components/alternatives/alternatives.component';
import {AboutComponent} from './components/pages/about/about.component';


const routes: Routes = [
  {path:'', component: TodosComponent},
  {path:'', component: AlternativesComponent, outlet:'secondary'},
  {path:'about', component: AboutComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
