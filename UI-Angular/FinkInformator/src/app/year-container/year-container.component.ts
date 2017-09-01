import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-year-container',
  templateUrl: './year-container.component.html',
  styleUrls: ['./year-container.component.css']
})
export class YearContainerComponent {
  @Output() setYear: EventEmitter<number> = new EventEmitter<number>();

  constructor() { }

  onClick(id) {
    this.setYear.emit(id);
  }

}
