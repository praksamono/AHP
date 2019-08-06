import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CriteriaItemComponent } from './Criteria-item.component';

describe('CriteriaItemComponent', () => {
  let component: CriteriaItemComponent;
  let fixture: ComponentFixture<CriteriaItemComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CriteriaItemComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CriteriaItemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
