import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import {  Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { Company } from '../model/icompany';

@Injectable({
  providedIn: 'root'
})
export class HttpmethodService {
  private apiServer = "http://localhost:3000";
  constructor(private httpClient : HttpClient) { }
  //Adding Headers
  httpOptions = {
    headers : new HttpHeaders({
      'Content-Type': 'application/json'
    })
  }

  //Add new Company
  create(company: any) : Observable<Company>{
    debugger;
    company.totalBranch = company.companyBranch.length;
    return this.httpClient.post<Company>(this.apiServer +'/companies/',JSON.stringify(company), this.httpOptions)
    .pipe(catchError(this.errorHandler))
  }

  //Get all Companies List
  getAll(): Observable<Company[]>{
    return this.httpClient.get<Company[]>(this.apiServer + '/companies/')
    .pipe(catchError(this.errorHandler))
  }

  //Get Company by ID
  getById(id: any) : Observable<Company>{
    return this.httpClient.get<Company>(this.apiServer + '/companies/' +id)
    .pipe(catchError(this.errorHandler))
  }

  //Edit or Update Company Details
  update(company: Company) {
    return this.httpClient.put<Company>(this.apiServer + '/companies/' + company.id, JSON.stringify(company), this.httpOptions)
    .pipe(
      catchError(this.errorHandler)
    )
  } 

  //Delete Company data
  delete(id: number) : Observable<Company>{
    return this.httpClient.delete<Company>(this.apiServer + '/companies/' +id, this.httpOptions)
    .pipe(catchError(this.errorHandler))
  }


  //Error Handler
  errorHandler(error: any) {
   let errorMsg = '';

    if(error.error instanceof ErrorEvent){
      errorMsg = error.error.message;
    }
    else{
      errorMsg = `ErrorCode : ${error.status}\nMessage: $ {error.Message}`;
    }
    console.log(errorMsg);
    return throwError(errorMsg);
  }

}
