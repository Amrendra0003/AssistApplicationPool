import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DashboardGuarantorComponent } from './dashboard-guarantor.component';

describe('DashboardGuarantorComponent', () => {
  let component: DashboardGuarantorComponent;
  let fixture: ComponentFixture<DashboardGuarantorComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DashboardGuarantorComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DashboardGuarantorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
