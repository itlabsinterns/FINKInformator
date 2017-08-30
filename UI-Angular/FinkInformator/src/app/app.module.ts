import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {HttpModule} from '@angular/http';
import {Ng2PageScrollModule} from 'ng2-page-scroll';

import { AppComponent } from './app.component';
import {NavbarComp} from './navbar/navbar.component';
import {Program} from './programComponent/program.component';
import {ProgramsService} from './services/programs.service';
import {CoursesService} from './services/courses.service';
import {ProgramContainer} from './programcontainer/programcontainer.component';
import { YearContainerComponent } from './year-container/year-container.component';
import { SemesterContainerComponent } from './semester-container/semester-container.component';
import {PageScrollService} from 'ng2-page-scroll';
import { NotificationBarModule } from 'angular2-notification-bar'
import { NotificationBarService } from 'angular2-notification-bar';
import { CoursesContainerComponent } from './courses-container/courses-container.component';
import { Course } from './course-component/course-component.component';
import { ProgramCourse } from './program-course/program-course.component';

@NgModule({
  declarations: [
    AppComponent,
    NavbarComp,
    Program,
    ProgramContainer,
    YearContainerComponent,
    SemesterContainerComponent,
    CoursesContainerComponent,
    Course,
    ProgramCourse,
    
  ],
  imports: [
    BrowserModule,
    HttpModule,
    Ng2PageScrollModule,
    NotificationBarModule
  ],
  providers: [ProgramsService,CoursesService,PageScrollService,NotificationBarService],
  bootstrap: [AppComponent]
})
export class AppModule { }
