import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DashboardApplicationFormsComponent } from './dashboard-application-forms.component';

describe('DashboardApplicationFormsComponent', () => {
  let component: DashboardApplicationFormsComponent;
  let fixture: ComponentFixture<DashboardApplicationFormsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DashboardApplicationFormsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DashboardApplicationFormsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
