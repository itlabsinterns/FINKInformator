import { Component, Inject } from '@angular/core';
import { NotificationBarService, NotificationType } from 'angular2-notification-bar'
import { OnInit } from '@angular/core';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{
  constructor(){}

  ngOnInit(){}
}
