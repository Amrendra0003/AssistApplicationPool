import { ComponentFixture, TestBed } from '@angular/core/testing';
import { DashboardDetailsComponent } from './patient-dashboard.component';
describe('DashboardDetailsComponent', () => {
  let component: DashboardDetailsComponent;
  let fixture: ComponentFixture<DashboardDetailsComponent>;
  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [DashboardDetailsComponent]
    })
      .compileComponents();
  });
  beforeEach(() => {
    fixture = TestBed.createComponent(DashboardDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });
  it('should create', () => {
    expect(component).toBeTruthy();
  });
});