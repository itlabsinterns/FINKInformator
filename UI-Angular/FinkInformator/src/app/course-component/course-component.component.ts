import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-course-component',
  templateUrl: './course-component.component.html',
  styleUrls: ['./course-component.component.css']
})
export class Course implements OnInit {

  constructor(
    public CourseId:number,
    public CourseName:string,
    public CourseDescription:string,
    public Semester:number
  ) { }

  ngOnInit() {
  }

}
