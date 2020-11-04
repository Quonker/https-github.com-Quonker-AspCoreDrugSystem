import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { retry, catchError } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { Drug } from '../models/drug';


@Injectable({
  providedIn: 'root'
})
export class DrugService {

  myAppUrl: string;
  myApiUrl: string;
  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json; charset=utf-8'
    })
  };
  constructor(private http: HttpClient) {
      this.myAppUrl = environment.appUrl;
      this.myApiUrl = 'api/Drug/';
  }

  getDrugs(): Observable<Drug[]> {
    return this.http.get<Drug[]>(this.myAppUrl + this.myApiUrl)
    .pipe(
      retry(1),
      catchError(this.errorHandler)
    );
  }

  getDrug(drugId: number): Observable<Drug> {
      return this.http.get<Drug>(this.myAppUrl + this.myApiUrl + drugId)
      .pipe(
        retry(1),
        catchError(this.errorHandler)
      );
  }

  saveDrug(drug): Observable<Drug> {
      return this.http.post<Drug>(this.myAppUrl + this.myApiUrl, JSON.stringify(drug), this.httpOptions)
      .pipe(
        retry(1),
        catchError(this.errorHandler)
      );
  }

  updateDrug(drugId: number, drug): Observable<Drug> {
      return this.http.put<Drug>(this.myAppUrl + this.myApiUrl + drugId, JSON.stringify(drug), this.httpOptions)
      .pipe(
        retry(1),
        catchError(this.errorHandler)
      );
  }

  deleteDrug(drugId: number): Observable<Drug> {
      return this.http.delete<Drug>(this.myAppUrl + this.myApiUrl + drugId)
      .pipe(
        retry(1),
        catchError(this.errorHandler)
      );
  }

  // tslint:disable-next-line: typedef
  errorHandler(error) {
    let errorMessage = '';
    if (error.error instanceof ErrorEvent) {
      // Get client-side error
      errorMessage = error.error.message;
    } else {
      // Get server-side error
      errorMessage = `Error Code: ${error.status}\nMessage: ${error.message}`;
    }
    console.log(errorMessage);
    return throwError(errorMessage);
  }
}
