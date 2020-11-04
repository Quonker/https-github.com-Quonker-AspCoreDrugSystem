import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Observable } from 'rxjs';
import {DrugService} from '../services/drug.service';
import {Drug} from '../models/drug';

@Component({
  selector: 'app-drug',
  templateUrl: './drug.component.html',
  styleUrls: ['./drug.component.scss']
})
export class DrugComponent implements OnInit {
  drug$: Observable<Drug>;
  drugId: number;

  constructor(private drugService: DrugService, private avRoute: ActivatedRoute) {
    const idParam = 'id';
    if (this.avRoute.snapshot.params[idParam]) {
      this.drugId = this.avRoute.snapshot.params[idParam];
    }
  }

  // tslint:disable-next-line: typedef
  ngOnInit() {
    this.loadDrug();
  }

  // tslint:disable-next-line: typedef
  loadDrug() {
    this.drug$ = this.drugService.getDrug(this.drugId);
  }
}
