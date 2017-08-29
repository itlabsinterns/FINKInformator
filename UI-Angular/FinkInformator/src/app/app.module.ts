import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {HttpModule} from '@angular/http';

import { AppComponent } from './app.component';
import {NavbarComp} from './navbar/navbar.component';
import {Program} from './programComponent/program.component';
import {ProgramsService} from './services/programs.service';
import {CoursesService} from './services/courses.service';
import {ProgramContainer} from './programcontainer/programcontainer.component';
import { YearContainerComponent } from './year-container/year-container.component';
import { SemesterContainerComponent } from './semester-container/semester-container.component';
import {PageScrollService} from 'ng2-page-scroll';

@NgModule({
  declarations: [
    AppComponent,
    NavbarComp,
    Program,
    ProgramContainer,
    YearContainerComponent,
    SemesterContainerComponent,
    
  ],
  imports: [
    BrowserModule,
    HttpModule,
  ],
  providers: [ProgramsService,CoursesService,PageScrollService],
  bootstrap: [AppComponent]
})
export class AppModule { }
