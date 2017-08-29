import { Component, Inject } from '@angular/core';
import {ProgramContainer} from './programcontainer/programcontainer.component';
import {DOCUMENT} from '@angular/common';
import {PageScrollInstance, PageScrollService, EasingLogic} from 'ng2-page-scroll';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent{
  programid:number=0;
  year:number=0;
  semester:number=0;

  public constructor(@Inject(DOCUMENT) private document: any, private pageScrollService:PageScrollService)
  {
    
  }

  onProgramClick(id) {
    this.programid=id;
  }

  onYearClick(year) {
    if(this.programid==0)
      {
        let pageScrollInstance: PageScrollInstance = PageScrollInstance.simpleInstance(this.document, 'programContainer');
        this.pageScrollService.start(pageScrollInstance);
        return;
      }
      else this.year=year;
  }

  onSemesterClick(semester) {
    if(this.programid==0)
      {
        let pageScrollInstance: PageScrollInstance = PageScrollInstance.simpleInstance(this.document, 'programContainer');
        this.pageScrollService.start(pageScrollInstance);
        return;
      }
      else if(this.year==0)
        {
          let pageScrollInstance: PageScrollInstance = PageScrollInstance.simpleInstance(this.document, 'app-year-container');
          this.pageScrollService.start(pageScrollInstance);
          return;
        }
    this.semester=semester;
  }
}
