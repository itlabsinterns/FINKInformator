import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppComponent } from './app.component';
import { NavbarComp } from './navbar/navbar.component';
import { NavbarsComponent } from './navbars/navbars.component';



@NgModule({
  declarations: [
    AppComponent,
    NavbarComp,
    NavbarsComponent
  ],
  imports: [
    BrowserModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
