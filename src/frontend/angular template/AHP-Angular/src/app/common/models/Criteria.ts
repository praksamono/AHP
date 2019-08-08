type Priority={
  [key:number]:-9 | -7 | -5 | -3 | -1 | 1 | 3 | 5 | 7 | 9;
}

export class Criteria{
    id:number;
    goalId:number;
    criteriumName:string;
    completed:boolean;
    order: number;

    constructor(name?: string) {
        this.criteriumName = name;
    }
}
