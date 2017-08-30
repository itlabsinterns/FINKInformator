import { Component, OnInit } from '@angular/core';
import { Course } from '../course-component/course-component.component';

@Component({
  selector: 'app-program-course',
  templateUrl: './program-course.component.html',
  styleUrls: ['./program-course.component.css']
})
export class ProgramCourse implements OnInit {

  constructor(
    public Course:Course,
    public IsMandatory:boolean,
    public Prerequisites:Course[]
  ) { }

  ngOnInit() {
  }

}
