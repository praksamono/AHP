import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {HttpClientModule} from '@angular/common/http';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';


import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { TodosComponent } from './components/todos/todos.component';
import { TodoItemComponent } from './components/todo-item/todo-item.component';
import { HeaderComponent } from './components/layout/header/header.component';
import { AddTodoComponent } from './components/add-todo/add-todo.component';
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




@NgModule({
  declarations: [
    AppComponent,
    TodosComponent,
    TodoItemComponent,
    HeaderComponent,
    AddTodoComponent,
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
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
