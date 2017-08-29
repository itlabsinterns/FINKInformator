import {Component} from '@angular/core';
import {ProgramsService} from '../services/programs.service';
import {OnInit} from '@angular/core';
import {Program} from '../programComponent/program.component';

@Component({
    selector:'programContainer',
    templateUrl:'./programcontainer.component.html',
    styleUrls:['./programcontainer.component.css']
})

export class ProgramContainer implements OnInit{
    programs:Program[]=[];

constructor(private _programsService:ProgramsService)
{

}

ngOnInit()
{
    this.displayPrograms();
}

displayPrograms()
{
    this._programsService.getPrograms()
    .subscribe(response =>
      {
          this.programs = response.Programs;
      });
}

}