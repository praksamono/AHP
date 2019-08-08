type Priority={
    [key:number]:-9 | -7 | -5 | -3 | -1 | 1 | 3 | 5 | 7 | 9;
}
export class Alternative{
    AlternativeId:number;
    alternativeName:string;
    completed:boolean;
    GlobalPriority:Priority;
    order: number;

    constructor(name?: string) {
        this.alternativeName = name;
    }
}
