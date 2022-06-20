import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DynamicQuestionsComponent } from './dynamic-questions.component';

describe('JsonFormComponent', () => {
  let component: DynamicQuestionsComponent;
  let fixture: ComponentFixture<DynamicQuestionsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DynamicQuestionsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DynamicQuestionsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
