import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';


@Component({
  selector: 'app-semester-container',
  templateUrl: './semester-container.component.html',
  styleUrls: ['./semester-container.component.css']
})
export class SemesterContainerComponent {
  @Output() setSemester: EventEmitter<number> = new EventEmitter<number>();

  constructor() { }

  onClick(semester) {
    this.setSemester.emit(semester);
  }
}
