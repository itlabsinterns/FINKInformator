import { Component, OnInit } from '@angular/core';
import { CourseProgramName } from '../models/courseProgramName';
import { CoursesService } from '../services/courses.service';
import { Router, Routes } from '@angular/router';

@Component({
    selector: 'nav-bar',
    templateUrl: './navbar.component.html',
    styleUrls: ['./navbar.component.css']
})

export class NavbarComp{
    courses:CourseProgramName[];

    constructor(private coursesService:CoursesService, private router: Router)
    {

    }

    fillList(value)
    {
        if(value.length < 3)
            return;

        this.coursesService.GetCourseProgramNames(value)
        .subscribe(response=>this.courses=response.CourseProgramNames);
    }

    onClick(courseId)
    {
        this.router.navigate(['/course', courseId]);
        this.courses=null;
    }
}

