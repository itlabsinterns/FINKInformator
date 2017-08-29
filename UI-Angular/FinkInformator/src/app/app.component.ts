import { Component } from '@angular/core';
import {ProgramContainer} from './programcontainer/programcontainer.component';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent{
  programid:number=0;
  year:number=0;
  semester:number=0;


  onProgramClick(id) {
    this.programid=id;
  }

  onYearClick(year) {
    this.year=year;
  }

  onSemesterClick(semester) {
    this.semester=semester;
  }
}
