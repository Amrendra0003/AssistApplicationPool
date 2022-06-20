import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DashboardQuickAssessmentComponent } from './dashboard-quick-assessment.component';

describe('DashboardQuickAssessmentComponent', () => {
  let component: DashboardQuickAssessmentComponent;
  let fixture: ComponentFixture<DashboardQuickAssessmentComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DashboardQuickAssessmentComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DashboardQuickAssessmentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
