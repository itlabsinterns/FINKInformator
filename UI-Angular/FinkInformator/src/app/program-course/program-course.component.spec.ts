import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ProgramCourse } from './program-course.component';

describe('ProgramCourse', () => {
  let component: ProgramCourse;
  let fixture: ComponentFixture<ProgramCourse>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ProgramCourse ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ProgramCourse);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should be created', () => {
    expect(component).toBeTruthy();
  });
});
