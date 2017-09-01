import { Course } from "./course";

export class ProgramCourse {

    constructor(
        public Course: Course,
        public IsMandatory: boolean,
        public Prerequisites: Course[]
    ) { }
}