import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { DrugComponent } from './drug/drug.component';
import { DrugsComponent } from './drugs/drugs.component';
import { DrugAddEditComponent } from './drug-add-edit/drug-add-edit.component';

const routes: Routes = [
  { path: '', component: DrugsComponent, pathMatch: 'full' },
  { path: 'drug/:id', component: DrugComponent },
  { path: 'add', component: DrugAddEditComponent },
  { path: 'drug/edit/:id', component: DrugAddEditComponent },
  { path: '**', redirectTo: '/' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
