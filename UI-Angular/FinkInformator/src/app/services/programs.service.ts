import {Injectable} from '@angular/core';
import { Observable } from 'rxjs';
import { Response, Http } from '@angular/http';
import {Program} from '../models/program';
import 'rxjs/add/operator/map';
import { Constants } from "./constants";

@Injectable()

export class ProgramsService
{
    constructor(private _http:Http)
    {

    }
    
    getPrograms(){
        return this._http.get(Constants.APIURL + "/programs")
        .map(response => response.json());
    }

    getProgramById(programId)
    {
        return this._http.get(Constants.APIURL + "/programs/"+programId)
        .map(response=>response.json());
    }

    GetProgramCourses(programId,semester)
    {
        return this._http.get(Constants.APIURL + "/programs/"+programId+"/"+semester)
        .map(response=>response.json());
    }

}