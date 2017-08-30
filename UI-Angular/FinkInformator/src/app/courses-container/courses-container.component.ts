import { Component, OnInit, Input } from '@angular/core';
import {Course} from '../course-component/course-component.component';
import {ProgramsService} from '../services/programs.service';
import { ProgramCourse } from '../program-course/program-course.component';

@Component({
  selector: 'app-courses-container',
  templateUrl: './courses-container.component.html',
  styleUrls: ['./courses-container.component.css']
})
export class CoursesContainerComponent implements OnInit {
  programCourses: ProgramCourse[]=[];
  @Input() programId: number;
  @Input() semester: number;

  _mandatoryCourses: ProgramCourse[]=[];
  _optionalCourses: ProgramCourse[]=[];

  constructor(private programsService:ProgramsService) { }

  ngOnInit() {
  
  }

  ngOnChanges()
  {
    console.log("changes");
    console.log(this.programId+" "+this.semester);
    if(this.programId>0 && this.semester>0)this.fillCourses(this.programId,this.semester);
  }

  fillCourses(programid, semester) {
    this._mandatoryCourses.splice(0,this._mandatoryCourses.length);
    this._optionalCourses.splice(0,this._optionalCourses.length);
    this.programsService.GetProgramCourses(programid, semester)
      .subscribe(response =>
        this.programCourses = response.ProgramsCoursesCustom);
    this.programCourses.forEach(element => {
      if(element.IsMandatory)this._mandatoryCourses.push(element);
      else this._optionalCourses.push(element);
    });
    
  }

}
