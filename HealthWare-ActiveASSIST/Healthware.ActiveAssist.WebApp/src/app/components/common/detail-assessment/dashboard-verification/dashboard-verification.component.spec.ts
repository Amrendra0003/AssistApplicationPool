import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DashboardVerificationComponent } from './dashboard-verification.component';

describe('DashboardVerificationComponent', () => {
  let component: DashboardVerificationComponent;
  let fixture: ComponentFixture<DashboardVerificationComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DashboardVerificationComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DashboardVerificationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
