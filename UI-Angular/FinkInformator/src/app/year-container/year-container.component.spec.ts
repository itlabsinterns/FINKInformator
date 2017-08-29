import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { YearContainerComponent } from './year-container.component';

describe('YearContainerComponent', () => {
  let component: YearContainerComponent;
  let fixture: ComponentFixture<YearContainerComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ YearContainerComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(YearContainerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should be created', () => {
    expect(component).toBeTruthy();
  });
});
