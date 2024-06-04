import { Injectable } from '@angular/core';
import { HttpClient, HttpParams, HttpErrorResponse } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { Lietsy } from '../../model/lietsy/lietsy';
import { environment } from 'src/environments/environment.development';

@Injectable({
  providedIn: 'root'
})
export class LietsyService {
  url: string = environment.apiBaseUrl + '/LietSy'
  list : Lietsy[]=[];
  constructor(private http: HttpClient) { }

  refreshList(): Observable<Lietsy[]> {
    return this.http.get<Lietsy[]>(`${this.url}/ShowListLietsy`)
      .pipe(
        catchError(this.handleError)
      );
  }

  createLietsy(data: any): Observable<Lietsy> {
    return this.http.post<Lietsy>(`${this.url}/Create`, data)
      .pipe(
        catchError(this.handleError)
      );
  }

  getLietsy(id: number): Observable<any> {
    return this.http.get<any>(`${this.url}/getLietsy/` + id)
      .pipe(
        catchError(this.handleError)
      );
  }

  updateLietsy(data: any): Observable<any> {
    return this.http.post<any>(`${this.url}/Update`, data)
      .pipe(
        catchError(this.handleError)
      );
  }

  deleteLietsy(id: number): Observable<any> {
    return this.http.delete<any>(`${this.url}/Delete/` + id)
      .pipe(
        catchError(this.handleError)
      );
  }
  searchLietsy(
    name: string,
    namSinh: number,
    namHySinh: number,
    thanhpho: number,
    quan: number,
    phuong: number,
    nghiaTrangThanhpho: number,
    nghiaTrangQuan: number,
    nghiaTrangPhuong: number,
    nghiaTrangId: number
  ): Observable<Lietsy[]> {
    let params = new HttpParams();
    if (name) params = params.append('name', name);
    if (namSinh) params = params.append('namSinh', namSinh.toString());
    if (namHySinh) params = params.append('namHySinh', namHySinh.toString());
    if (thanhpho) params = params.append('thanhpho', thanhpho.toString());
    if (quan) params = params.append('quan', quan.toString());
    if (phuong) params = params.append('phuong', phuong.toString());
    if (nghiaTrangThanhpho) params = params.append('nghiaTrangThanhpho', nghiaTrangThanhpho.toString());
    if (nghiaTrangQuan) params = params.append('nghiaTrangQuan', nghiaTrangQuan.toString());
    if (nghiaTrangPhuong) params = params.append('nghiaTrangPhuong', nghiaTrangPhuong.toString());
    if (nghiaTrangId) params = params.append('nghiaTrangId', nghiaTrangId.toString());

    return this.http.get<Lietsy[]>(`${this.url}/search`, { params })
      .pipe(
        catchError(this.handleError)
      );
  }

  getLietsyChild(id: number): Observable<Lietsy[]> {
    return this.http.get<Lietsy[]>(`${this.url}/getLietsyChild/` + id)
      .pipe(
        catchError(this.handleError)
      );
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
