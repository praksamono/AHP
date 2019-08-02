type Priority={
  [key:number]:-9 | -7 | -5 | -3 | -1 | 1 | 3 | 5 | 7 | 9;
}

export class Todo{
    id:number;
    goalId:number;
    CriteriumName:string;
    completed:boolean;
}
