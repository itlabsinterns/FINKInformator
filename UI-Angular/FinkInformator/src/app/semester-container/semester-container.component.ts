import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';


@Component({
  selector: 'app-semester-container',
  templateUrl: './semester-container.component.html',
  styleUrls: ['./semester-container.component.css']
})
export class SemesterContainerComponent implements OnInit {
@Output() setSemester: EventEmitter<number>=new EventEmitter<number>();

  constructor() { }

  ngOnInit() {
  }

  onClick(semester)
  {
    this.setSemester.emit(semester);
  }
}
