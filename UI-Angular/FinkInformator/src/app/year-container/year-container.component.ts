import { Component, OnInit, Input, Output, EventEmitter} from '@angular/core';

@Component({
  selector: 'app-year-container',
  templateUrl: './year-container.component.html',
  styleUrls: ['./year-container.component.css']
})
export class YearContainerComponent implements OnInit {
  @Output() setYear: EventEmitter<number> = new EventEmitter<number>();

  constructor() { }

  ngOnInit() {
  }

  onClick(id)
  {
    this.setYear.emit(id);
  }

}
