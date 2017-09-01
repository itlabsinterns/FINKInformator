import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { Course } from '../models/course';
import { ProgramsService } from '../services/programs.service';
import { ProgramCourse } from '../models/programCourse';
import { Router, Routes } from '@angular/router';

@Component({
  selector: 'app-courses-container',
  templateUrl: './courses-container.component.html',
  styleUrls: ['./courses-container.component.css']
})
export class CoursesContainerComponent {
  @Input() programId: number;
  @Input() semester: number;
  @Output() setCourse: EventEmitter<number> = new EventEmitter<number>();

  mandatoryCourses: ProgramCourse[];
  optionalCourses: ProgramCourse[];

  constructor(private programsService: ProgramsService, private router: Router) { }

  ngOnChanges() {
    if (this.programId > 0 && this.semester > 0) 
      this.fillCourses(this.programId, this.semester);
  }

  fillCourses(programId, semester) {

    this.mandatoryCourses = [];
    this.optionalCourses = [];

    this.programsService.GetProgramCourses(programId, semester)
      .subscribe(response => {
        response.ProgramsCoursesDto.forEach(element => {
          if (element.IsMandatory) 
            this.mandatoryCourses.push(element);
          else 
            this.optionalCourses.push(element);
        });
      });
  }

  onClick(id) {
    this.router.navigate(['/course', id]);
  }
}
