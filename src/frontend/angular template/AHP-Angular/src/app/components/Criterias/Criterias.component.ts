import { Component, OnInit } from '@angular/core';
import{ CriteriaService} from '../../common/services/Criteria.service';
import {Criteria} from '../../common/models/Criteria';
import { Observable } from 'rxjs';


@Component({
    selector: 'app-Criterias',
    templateUrl: './Criterias.component.html',
    styleUrls: ['./Criterias.component.css']
})
export class CriteriasComponent implements OnInit {

    constructor() { }

    ngOnInit() { }
}
