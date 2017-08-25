import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {HttpModule} from '@angular/http';

import { AppComponent } from './app.component';
import {HeaderComponent} from './header.component';
import {Program} from './program.component';
import {ProgramsService} from './programs.service';
import {ProgramContainer} from './programcontainer.component';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    Program,
    ProgramContainer
  ],
  imports: [
    BrowserModule,
    HttpModule
  ],
  providers: [ProgramsService],
  bootstrap: [AppComponent]
})
export class AppModule { }
