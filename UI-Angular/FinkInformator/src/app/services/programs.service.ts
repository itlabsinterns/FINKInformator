import {Injectable} from '@angular/core';
import { Observable } from 'rxjs';
import { Response, Http } from '@angular/http';
import {Program} from '../programComponent/program.component';
import 'rxjs/add/operator/map';

@Injectable()

export class ProgramsService
{
    constructor(private _http:Http)
    {

    }
    
    getPrograms(){
        return this._http.get("http://localhost:4329/programs")
        .map(res => res.json());
    }
}