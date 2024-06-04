// auth.interceptor.ts
import { Injectable } from '@angular/core';
import { HttpEvent, HttpInterceptor, HttpHandler, HttpRequest } from '@angular/common/http';
import { Observable } from 'rxjs';
import { AuthService } from './auth.service'; // Đảm bảo đường dẫn chính xác

@Injectable()
export class AuthInterceptor implements HttpInterceptor {
  constructor(private auth: AuthService) {}

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    if (this.auth.isAuthenticated) {
      const authToken = this.auth.token; // Sử dụng thuộc tính token thay vì phương thức getToken
      const authReq = req.clone({
        headers: req.headers.set('Authorization', `Bearer ${authToken}`)
      });
      return next.handle(authReq);
    } else {
      return next.handle(req);
    }
  }
}
