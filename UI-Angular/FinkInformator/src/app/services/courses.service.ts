import {Injectable} from '@angular/core';
import { Observable } from 'rxjs';
import { Response, Http } from '@angular/http';
import 'rxjs/add/operator/map';

@Injectable()

export class CoursesService
{
    constructor(private _http:Http)
    {

    }
    
    getCourses(){
        return this._http.get("http://localhost:4329/courses")
        .map(response => response.json());
    }

    getCourseById(courseId)
    {
        return this._http.get("http://localhost:4329/courses/"+courseId)
        .map(response=>response.json());
    }

    GetCoursePrerequisites(courseId)
    {
        return this._http.get("http://localhost:4329/courses/"+courseId+"/prerequisites")
        .map(response=>response.json());
    }

    GetCourseProgramNames(value)
    {
        return this._http.get("http://localhost:4329/courses/names/"+value)
        .map(response=>response.json());
    }

}