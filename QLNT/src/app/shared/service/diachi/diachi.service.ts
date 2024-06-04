import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { environment } from 'src/environments/environment.development';
import { Diachi } from '../../model/diachi/diachi'; 
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class DiachiService {
  url:string=environment.apiBaseUrl+'/DiaChi'
  list : Diachi[]=[];

  
  constructor(private http:HttpClient) { }
  refreshList():Observable<Array<Diachi>> {
    return this.http.get<Array<Diachi>>(this.url+'/ShowListDiaChi')   
}
createDiaChi(data: any): Observable<Diachi> {
  return this.http.post<any>(`${this.url}/Create`, data)
    
}
getDiaChi(id: number): Observable<any> {
  return this.http.get<any>(`${this.url}/getDiaChi/` + id);
}
updateDiaChi(data:any): Observable<any> {
  return this.http.post<any>(`${this.url}/Update`, data)
    
}
deleteDiaChi(id:number):Observable<any>{
  return this.http.delete<any>(`${this.url}/Delete/`+ id);
}
getDiaChiChild(id:number):Observable<Array<Diachi>> {
  return this.http.get<Array<Diachi>>(this.url+'/getDiaChiChild/'+id)   
}
updateDiaChiChild(data:any): Observable<any> {
  return this.http.post<any>(`${this.url}/UpdateChild`, data)
    
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

