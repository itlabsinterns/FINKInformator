import { Component, OnInit, OnChanges, Input } from '@angular/core';
import { Course } from '../models/course';
import { CoursesService } from '../services/courses.service';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';
import 'rxjs/add/operator/switchMap';
import { Constants } from '../services/constants';

@Component({
  selector: 'app-course-details',
  templateUrl: './course-details.component.html',
  styleUrls: ['./course-details.component.css']
})
export class CourseDetailsComponent implements OnInit {
  courseId;
  observator:any;

  selectedCourse: Course;
  prerequisites: Course[] = [];
  url:string;

  constructor(private coursesService: CoursesService,
    private route: ActivatedRoute,
    private router: Router) {
      this.url=Constants.APIURL+"/";
  }

  ngOnInit() {
    this.route.params.subscribe(params=>
    {
      this.courseId = this.route.snapshot.paramMap.get('id');
      this.setCourse(this.courseId);
      this.setCoursePrerequisites(this.courseId);      
    });
  }

  setCourse(courseId) {
    this.coursesService.getCourseById(courseId)
      .subscribe(response =>
        this.selectedCourse = response.Course
      );
  }

  setCoursePrerequisites(courseId) {
    this.coursesService.GetCoursePrerequisites(courseId)
      .subscribe(response => this.prerequisites = response.Prerequisites);
  }

}
