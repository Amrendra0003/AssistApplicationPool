import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { QuickAssessmentComponent } from './quick-assessment.component';
describe('QuickAssessmentComponent', () => {
  let component: QuickAssessmentComponent;
  let fixture: ComponentFixture<QuickAssessmentComponent>;
  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [QuickAssessmentComponent]
    })
      .compileComponents();
  }));
  beforeEach(() => {
    fixture = TestBed.createComponent(QuickAssessmentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });
  it('should create', () => {
    expect(component).toBeTruthy();
  });
});