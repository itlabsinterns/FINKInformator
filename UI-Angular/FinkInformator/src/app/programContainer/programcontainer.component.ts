import { Component, Input, Output, EventEmitter } from '@angular/core';
import { ProgramsService } from '../services/programs.service';
import { OnInit } from '@angular/core';
import { Program } from "../models/program";

@Component({
    selector: 'app-program-container',
    templateUrl: './programcontainer.component.html',
    styleUrls: ['./programcontainer.component.css']
})

export class ProgramContainer implements OnInit {
    programs: Program[] = [];
    @Output() setProgram: EventEmitter<number> = new EventEmitter<number>();

    constructor(private _programsService: ProgramsService) {

    }

    ngOnInit() {
        this.displayPrograms();
    }

    displayPrograms() {
        this._programsService.getPrograms()
            .subscribe(response => {
                this.programs = response.Programs;
            });
    }

    onClick(programId){
        this.setProgram.emit(programId);
    }
}