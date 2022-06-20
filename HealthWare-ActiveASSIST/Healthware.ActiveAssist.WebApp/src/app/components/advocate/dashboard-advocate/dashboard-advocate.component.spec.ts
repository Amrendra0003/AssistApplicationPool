import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { DashboardAdvocateComponent } from './dashboard-advocate.component';
describe('DasboardAdvocateComponent', () => {
  let component: DashboardAdvocateComponent;
  let fixture: ComponentFixture<DashboardAdvocateComponent>;
  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [DashboardAdvocateComponent]
    })
      .compileComponents();
  }));
  beforeEach(() => {
    fixture = TestBed.createComponent(DashboardAdvocateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });
  it('should create', () => {
    expect(component).toBeTruthy();
  });
});