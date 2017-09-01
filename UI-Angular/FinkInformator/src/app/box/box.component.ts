import { Component, OnInit, Inject } from '@angular/core';
import { ProgramContainer } from '../programcontainer/programcontainer.component';
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

export class BoxComponent {
  programid: number=0;
  year: number=0;
  semester: number=0;
  evaluatedSemester: number;

  showCoursesContainer: boolean = false;

  constructor(private pageScrollService: PageScrollService, @Inject(DOCUMENT) private document: any,
    private notificationBarService: NotificationBarService) {

  }

  onProgramClick(id) {
    this.programid = id;
    let pageScrollInstance: PageScrollInstance = PageScrollInstance.simpleInstance(this.document, 'app-year-container');
    this.pageScrollService.start(pageScrollInstance);
  }

  onYearClick(year) {
    if (this.programid == 0) {
      let pageScrollInstance: PageScrollInstance = PageScrollInstance.simpleInstance(this.document, 'app-program-container');
      this.pageScrollService.start(pageScrollInstance);
      setTimeout(() => this.notificationBarService.create({ message: 'Please select program', type: NotificationType.Error }), 1300);
    }
    else {
      this.year = year;
      let pageScrollInstance: PageScrollInstance = PageScrollInstance.simpleInstance(this.document, 'app-semester-container');
      this.pageScrollService.start(pageScrollInstance);
    }
  }

  onSemesterClick(semester) {
    if (this.programid == 0) {
      let pageScrollInstance: PageScrollInstance = PageScrollInstance.simpleInstance(this.document, 'app-program-container');
      this.pageScrollService.start(pageScrollInstance);
      setTimeout(() => this.notificationBarService.create({ message: 'Please select program', type: NotificationType.Error }), 1300);
    }
    else if (this.year == 0) {
      let pageScrollInstance: PageScrollInstance = PageScrollInstance.simpleInstance(this.document, 'app-year-container');
      this.pageScrollService.start(pageScrollInstance);
      setTimeout(() => this.notificationBarService.create({ message: 'Please select year', type: NotificationType.Error }), 1300);
    }
    else {
      this.semester = semester;
      this.evaluatedSemester = this.year * 2 + (this.semester - 2);
      this.showCoursesContainer = true;
      let pageScrollInstance: PageScrollInstance = PageScrollInstance.simpleInstance(this.document, 'app-courses-container');
      this.pageScrollService.start(pageScrollInstance);
    }
  }

}
