import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import {DrugService} from '../services/drug.service';
import {Drug} from '../models/drug';

@Component({
  selector: 'app-drugs',
  templateUrl: './drugs.component.html',
  styleUrls: ['./drugs.component.scss']
})
export class DrugsComponent implements OnInit {
  drugs$: Observable<Drug[]>;

  constructor(private drugService: DrugService) { }

  ngOnInit(): void {
    this.loadDrugs();
  }

  // tslint:disable-next-line: typedef
  loadDrugs() {
    this.drugs$ = this.drugService.getDrugs();
  }

  // tslint:disable-next-line: typedef
  delete(drugId) {
    const ans = confirm('Do you want to delete drug with id: ' + drugId);
    if (ans) {
      this.drugService.deleteDrug(drugId).subscribe((data) => {
        this.loadDrugs();
      });
    }
  }
}
