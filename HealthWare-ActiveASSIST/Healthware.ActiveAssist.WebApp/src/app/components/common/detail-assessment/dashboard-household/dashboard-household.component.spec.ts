import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DashboardHouseholdComponent } from './dashboard-household.component';

describe('DashboardHouseholdComponent', () => {
  let component: DashboardHouseholdComponent;
  let fixture: ComponentFixture<DashboardHouseholdComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DashboardHouseholdComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DashboardHouseholdComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
