import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DashboardProgramsComponent } from './dashboard-programs.component';

describe('DashboardProgramsComponent', () => {
  let component: DashboardProgramsComponent;
  let fixture: ComponentFixture<DashboardProgramsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DashboardProgramsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DashboardProgramsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
