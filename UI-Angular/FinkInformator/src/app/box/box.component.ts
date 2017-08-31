import { Component, OnInit, Inject } from '@angular/core';
import {ProgramContainer} from '../programcontainer/programcontainer.component';
import { YearContainerComponent } from '../year-container/year-container.component';
import { SemesterContainerComponent } from '../semester-container/semester-container.component';
import { CoursesContainerComponent } from '../courses-container/courses-container.component';
import { PageScrollConfig, PageScrollService, PageScrollInstance } from 'ng2-page-scroll';
import { DOCUMENT } from '@angular/common';
import { NotificationBarService, NotificationType } from 'angular2-notification-bar'


@Component({
  selector: 'app-box',
  templateUrl: './box.component.html',
  styleUrls: ['./box.component.css']
})
export class BoxComponent implements OnInit {
  programid:number;
  year:number;
  semester:number;
  evaluatedSemester:number;

  selectedId:number;
  showCoursesContainer:boolean=false;

  constructor(private pageScrollService: PageScrollService, @Inject(DOCUMENT) private document: any,
  private notificationBarService:NotificationBarService)
  {

  }

  ngOnInit(){}

  onProgramClick(id) {
    this.programid=id;
    let pageScrollInstance: PageScrollInstance = PageScrollInstance.simpleInstance(this.document, 'app-year-container');
    this.pageScrollService.start(pageScrollInstance);
  }

  onYearClick(year) {
    if (this.programid == 0) {
      let pageScrollInstance: PageScrollInstance = PageScrollInstance.simpleInstance(this.document, 'programContainer');
      this.pageScrollService.start(pageScrollInstance);
      setTimeout(()=>this.notificationBarService.create({ message: 'PROGRAM NOT SELECTED!', type: NotificationType.Error}),1300);      
    }
    else {
      this.year = year;
      let pageScrollInstance: PageScrollInstance = PageScrollInstance.simpleInstance(this.document, 'app-semester-container');
      this.pageScrollService.start(pageScrollInstance);
    }

  }

  onSemesterClick(semester) {
    if (this.programid == 0) {
      let pageScrollInstance: PageScrollInstance = PageScrollInstance.simpleInstance(this.document, 'programContainer');
      this.pageScrollService.start(pageScrollInstance);
      setTimeout(() => this.notificationBarService.create({ message: 'PROGRAM NOT SELECTED!', type: NotificationType.Error }), 1300);
    }
    else if (this.year == 0) {
      let pageScrollInstance: PageScrollInstance = PageScrollInstance.simpleInstance(this.document, 'app-year-container');
      this.pageScrollService.start(pageScrollInstance);
      setTimeout(() => this.notificationBarService.create({ message: 'YEAR NOT SELECTED!', type: NotificationType.Error }), 1300);
    }
    else {
    this.semester = semester;
    this.evaluatedSemester=this.year*2+(this.semester-2);
    this.showCoursesContainer=true;
      let pageScrollInstance: PageScrollInstance = PageScrollInstance.simpleInstance(this.document, 'app-courses-container');
      this.pageScrollService.start(pageScrollInstance);
    }
  }
}
