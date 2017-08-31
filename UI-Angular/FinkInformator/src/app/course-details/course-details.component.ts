import { Component, OnInit, OnChanges, Input } from '@angular/core';
import { Course } from '../course-component/course-component.component';
import { CoursesService } from '../services/courses.service';


@Component({
  selector: 'app-course-details',
  templateUrl: './course-details.component.html',
  styleUrls: ['./course-details.component.css']
})
export class CourseDetailsComponent implements OnInit, OnChanges{
  @Input() courseId:number;

  selectedCourse:Course;
  prerequisites:Course[]=[];

  constructor(private coursesService:CoursesService) { 
    
  }

  ngOnInit() {
   
  }

  ngOnChanges() {
    console.log("changes detected");
    this.setCourse(this.courseId);
    this.setCoursePrerequisites(this.courseId);
  }

  setCourse(courseId)
  {
    this.coursesService.getCourseById(courseId)
    .subscribe(response=>this.selectedCourse=response.Course);
  }

  setCoursePrerequisites(courseId)
  {
    this.coursesService.GetCoursePrerequisites(courseId)
    .subscribe(response=>this.prerequisites=response.Prerequisites);
  }

}
