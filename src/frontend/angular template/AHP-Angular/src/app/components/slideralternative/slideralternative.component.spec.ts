import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SlideralternativeComponent } from './slideralternative.component';

describe('SlideralternativeComponent', () => {
  let component: SlideralternativeComponent;
  let fixture: ComponentFixture<SlideralternativeComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SlideralternativeComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SlideralternativeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
