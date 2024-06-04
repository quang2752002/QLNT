import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { environment } from 'src/environments/environment.development';
import { Nghiatrang } from '../../model/nghiatrang/nghiatrang'; 
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class NghiatrangService {
  private url: string = `${environment.apiBaseUrl}/NghiaTrang`;

  constructor(private http: HttpClient) { }

  refreshList(): Observable<Array<Nghiatrang>> {
    return this.http.get<Array<Nghiatrang>>(`${this.url}/ShowListNghiaTrang`)
      .pipe(
        catchError(this.handleError)
      );
  }
  createNghiaTrang(data: any): Observable<Nghiatrang> {
    return this.http.post<any>(`${this.url}/Create`, data)
      
  }
  getNghiaTrang(id: number): Observable<any> {
    return this.http.get<any>(`${this.url}/getNghiaTrang/` + id);
  }
  updateNghiaTrang(data:any): Observable<any> {
    return this.http.post<any>(`${this.url}/Update`, data)
      
  }
  deleteNghiaTrang(id:number):Observable<any>{
    return this.http.delete<any>(`${this.url}/Delete/`+ id);
  }
  private handleError(error: HttpErrorResponse): Observable<never> {
    let errorMessage = '';
    if (error.error instanceof ErrorEvent) {
      errorMessage = `An error occurred: ${error.error.message}`;
    } else {
      errorMessage = `Backend returned code ${error.status}, body was: ${error.message}`;
    }
    return throwError(errorMessage);
  }
}
