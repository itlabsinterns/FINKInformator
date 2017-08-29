import { Component } from '@angular/core';

@Component({
    selector: 'program',
    templateUrl: './program.component.html',
    styleUrls: ['./program.component.css']
})

export class Program {

    constructor(
        public ProgramId: number = undefined,
        public ProgramName: string = '') {

    }

}