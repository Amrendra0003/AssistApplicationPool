import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DashboardWorkAddressComponent } from './dashboard-work-address.component';

describe('DashboardWorkAddressComponent', () => {
  let component: DashboardWorkAddressComponent;
  let fixture: ComponentFixture<DashboardWorkAddressComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DashboardWorkAddressComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DashboardWorkAddressComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
