import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import {DrugService} from '../services/drug.service';
import {Drug} from '../models/drug';

@Component({
  selector: 'app-drug-add-edit',
  templateUrl: './drug-add-edit.component.html',
  styleUrls: ['./drug-add-edit.component.scss']
})
export class DrugAddEditComponent implements OnInit {

  form: FormGroup;
  actionType: string;
  formTradename: string;
  drugId: number;
  errorMessage: any;
  existingDrug: Drug;
  constructor(private drugService: DrugService, private formBuilder: FormBuilder, private avRoute: ActivatedRoute, private router: Router)
  {
    const idParam = 'id';
    this.actionType = 'Add';
    this.formTradename = 'tradename';
    if (this.avRoute.snapshot.params[idParam]) {
      this.drugId = this.avRoute.snapshot.params[idParam];
  }

    this.form = this.formBuilder.group(
    {
      postId: 0,
      tradename: ['', [Validators.required]],
    }
  );
  }
  ngOnInit(): void {
    if (this.drugId > 0) {
      this.actionType = 'Edit';
      this.drugService.getDrug(this.drugId)
        .subscribe(data => (
          this.existingDrug = data,
          this.form.controls[this.formTradename].setValue(data.tradename)
        ));
    }
  }

  // tslint:disable-next-line: typedef
  save() {
    if (!this.form.valid) {
      return;
    }

    if (this.actionType === 'Add') {
      // tslint:disable-next-line: prefer-const
      let drug: Drug = {
        tradename: this.form.get(this.formTradename).value,
      };

      this.drugService.saveDrug(drug)
        .subscribe((data) => {
          this.router.navigate(['/drug', data.drugId]);
        });
    }

    if (this.actionType === 'Edit') {
      const drug: Drug = {
        drugId: this.existingDrug.drugId,
        tradename: this.form.get(this.formTradename).value,
      };
      this.drugService.updateDrug(drug.drugId, drug)
        .subscribe((data) => {
          this.router.navigate([this.router.url]);
        });
    }
  }

  // tslint:disable-next-line: typedef
  cancel() {
    this.router.navigate(['/']);
  }

  // tslint:disable-next-line: typedef
  get tradename() { return this.form.get(this.formTradename); }

}

