import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { Course } from './course-component.component';

describe('CourseComponentComponent', () => {
  let component: Course;
  let fixture: ComponentFixture<Course>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ Course ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(Course);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should be created', () => {
    expect(component).toBeTruthy();
  });
});
