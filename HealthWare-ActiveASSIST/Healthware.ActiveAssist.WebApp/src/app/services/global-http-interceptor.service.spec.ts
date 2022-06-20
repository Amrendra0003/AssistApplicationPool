import { TestBed } from '@angular/core/testing';
import { GlobalHttpInterceptorService as GlobalHttpInterceptorService } from './global-http-interceptor.service';
describe('GlobalHttpInterceptorServiceService', () => {
  let service: GlobalHttpInterceptorService;
  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(GlobalHttpInterceptorService);
  });
  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});