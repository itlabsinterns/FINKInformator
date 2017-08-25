import {Component} from '@angular/core';

@Component({
    selector:'program',
    template:'<span>{{ProgramName}}</span>'
})

export class Program
{

constructor(
public ProgramId:number=undefined,
public ProgramName:string='')
{

}

}