import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ResultsInterfaceComponent } from './results-interface.component';

describe('ResultsInterfaceComponent', () => {
  let component: ResultsInterfaceComponent;
  let fixture: ComponentFixture<ResultsInterfaceComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ResultsInterfaceComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ResultsInterfaceComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
