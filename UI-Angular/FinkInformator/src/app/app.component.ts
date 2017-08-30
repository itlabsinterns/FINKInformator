import { Component, Inject } from '@angular/core';
import {ProgramContainer} from './programcontainer/programcontainer.component';
import { PageScrollConfig, PageScrollService, PageScrollInstance } from 'ng2-page-scroll';
import { DOCUMENT } from '@angular/common';
import { NotificationBarService, NotificationType } from 'angular2-notification-bar'
import { OnInit } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{
  programid:number=0;
  year:number=0;
  semester:number=0;

  constructor(private pageScrollService: PageScrollService, @Inject(DOCUMENT) private document: any,private notificationBarService:NotificationBarService)
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
      setTimeout(()=>this.notificationBarService.create({ message: 'PROGRAM NOT SELECTED!', type: NotificationType.Error}),1300);
    }
    else if (this.year==0){
        let pageScrollInstance: PageScrollInstance = PageScrollInstance.simpleInstance(this.document, 'app-year-container');
        this.pageScrollService.start(pageScrollInstance);
        setTimeout(()=>this.notificationBarService.create({ message: 'YEAR NOT SELECTED!', type: NotificationType.Error}),1300);
    }
    else this.semester=semester;
    
  }
}
