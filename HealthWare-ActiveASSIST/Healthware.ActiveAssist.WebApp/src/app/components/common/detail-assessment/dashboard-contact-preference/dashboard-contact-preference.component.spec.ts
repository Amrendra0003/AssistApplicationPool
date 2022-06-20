import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DashboardContactPreferenceComponent } from './dashboard-contact-preference.component';

describe('DashboardContactPreferenceComponent', () => {
  let component: DashboardContactPreferenceComponent;
  let fixture: ComponentFixture<DashboardContactPreferenceComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DashboardContactPreferenceComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DashboardContactPreferenceComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
