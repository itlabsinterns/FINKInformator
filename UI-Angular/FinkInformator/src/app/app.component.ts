import { Component, Inject } from '@angular/core';
import {ProgramContainer} from './programcontainer/programcontainer.component';
import { PageScrollConfig, PageScrollService, PageScrollInstance } from 'ng2-page-scroll';
import { DOCUMENT } from '@angular/common';



@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent{
  programid:number=0;
  year:number=0;
  semester:number=0;

  constructor(private pageScrollService: PageScrollService, @Inject(DOCUMENT) private document: any)
  {

  }

  onProgramClick(id) {
    this.programid=id;
  }

  onYearClick(year) {
    if (this.programid == 0) {
      alert("heree");
      let pageScrollInstance: PageScrollInstance = PageScrollInstance.simpleInstance(this.document, '#programContainer');
      this.pageScrollService.start(pageScrollInstance);
    }
    else {
      this.year = year;
      alert(this.year);
    }

  }

  onSemesterClick(semester) {
    this.semester=semester;
  }
}
