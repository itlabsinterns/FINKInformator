import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import {Course} from '../course-component/course-component.component';
import {ProgramsService} from '../services/programs.service';
import { ProgramCourse } from '../program-course/program-course.component';
import { Router, Routes } from '@angular/router';

@Component({
  selector: 'app-courses-container',
  templateUrl: './courses-container.component.html',
  styleUrls: ['./courses-container.component.css']
})
export class CoursesContainerComponent implements OnInit {
  @Input() programId: number;
  @Input() semester: number;
  @Output() selectedId: EventEmitter<number>=new EventEmitter<number>();

  _mandatoryCourses: ProgramCourse[];
  _optionalCourses: ProgramCourse[];
  

  constructor(private programsService:ProgramsService, private router: Router) { }

  ngOnInit() {
    
  }

  ngOnChanges()
  {
    if(this.programId>0 && this.semester>0)this.fillCourses(this.programId,this.semester);
  }

  fillCourses(programid, semester) {
    console.log("function called with "+programid+" "+semester);
    this._mandatoryCourses=[];
    this._optionalCourses=[];
    this.programsService.GetProgramCourses(programid, semester)
      .subscribe(response =>
        {
          response.ProgramsCoursesDto.forEach(element => {
          if(element.IsMandatory)this._mandatoryCourses.push(element);
          else this._optionalCourses.push(element);
        });
      });
  }

  onClick(id)
  {
    this.router.navigate(['/course', id]);
  }
 
}
