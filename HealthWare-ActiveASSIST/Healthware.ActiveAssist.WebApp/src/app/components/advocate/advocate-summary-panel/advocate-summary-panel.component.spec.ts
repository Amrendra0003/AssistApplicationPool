import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { AdvocateSummaryPanelComponent } from './advocate-summary-panel.component';
describe('AdvocateSummaryPanelComponent', () => {
  let component: AdvocateSummaryPanelComponent;
  let fixture: ComponentFixture<AdvocateSummaryPanelComponent>;
  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [AdvocateSummaryPanelComponent]
    })
      .compileComponents();
  }));
  beforeEach(() => {
    fixture = TestBed.createComponent(AdvocateSummaryPanelComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });
  it('should create', () => {
    expect(component).toBeTruthy();
  });
});