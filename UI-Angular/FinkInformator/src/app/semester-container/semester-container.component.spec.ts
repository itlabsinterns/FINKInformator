import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SemesterContainerComponent } from './semester-container.component';

describe('SemesterContainerComponent', () => {
  let component: SemesterContainerComponent;
  let fixture: ComponentFixture<SemesterContainerComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SemesterContainerComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SemesterContainerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should be created', () => {
    expect(component).toBeTruthy();
  });
});
