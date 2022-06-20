import { TestBed } from '@angular/core/testing';
import { QuickAssessmentService } from './quick-assessment.service';
describe('QuickAssessmentService', () => {
  let service: QuickAssessmentService;
  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(QuickAssessmentService);
  });
  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});