import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {HttpModule} from '@angular/http';
import { NguiParallaxScrollModule }  from '@ngui/parallax-scroll';

import { AppComponent } from './app.component';
import {NavbarComp} from './navbar/navbar.component';
import {Program} from './programComponent/program.component';
import {ProgramsService} from './services/programs.service';
import {CoursesService} from './services/courses.service';
import {ProgramContainer} from './programcontainer/programcontainer.component';

@NgModule({
  declarations: [
    AppComponent,
    NavbarComp,
    Program,
    ProgramContainer
  ],
  imports: [
    BrowserModule,
    HttpModule,
    NguiParallaxScrollModule
  ],
  providers: [ProgramsService,CoursesService],
  bootstrap: [AppComponent]
})
export class AppModule { }
