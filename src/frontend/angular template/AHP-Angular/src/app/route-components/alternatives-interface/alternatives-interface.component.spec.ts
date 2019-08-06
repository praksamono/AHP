import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AlternativesInterfaceComponent } from './alternatives-interface.component';

describe('AlternativesInterfaceComponent', () => {
  let component: AlternativesInterfaceComponent;
  let fixture: ComponentFixture<AlternativesInterfaceComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AlternativesInterfaceComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AlternativesInterfaceComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
