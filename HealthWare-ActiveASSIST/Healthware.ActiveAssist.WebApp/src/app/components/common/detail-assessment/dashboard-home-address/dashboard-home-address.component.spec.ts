import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DashboardHomeAddressComponent } from './dashboard-home-address.component';

describe('DashboardHomeAddressComponent', () => {
  let component: DashboardHomeAddressComponent;
  let fixture: ComponentFixture<DashboardHomeAddressComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DashboardHomeAddressComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DashboardHomeAddressComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
