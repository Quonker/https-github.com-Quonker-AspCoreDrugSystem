import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { DrugComponent } from './drug/drug.component';
import { DrugsComponent } from './drugs/drugs.component';
import { DrugAddEditComponent } from './drug-add-edit/drug-add-edit.component';
import { DrugService} from './services/drug.service';

@NgModule({
  declarations: [
    AppComponent,
    DrugComponent,
    DrugsComponent,
    DrugAddEditComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    ReactiveFormsModule
  ],
  providers: [
    DrugService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
