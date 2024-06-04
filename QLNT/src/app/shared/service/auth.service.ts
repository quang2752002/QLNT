// auth.service.ts
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';
import { CookieService } from 'ngx-cookie-service';
import { tap } from 'rxjs/operators';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private jwtHelper = new JwtHelperService();

  constructor(private http: HttpClient, private router: Router, private cookieService: CookieService) {}

  login(username: string, password: string): Observable<boolean> {
    return this.http.post<{ token: string }>('/api/auth/login', { username, password }).pipe(
      map(response => { // Sử dụng toán tử map để chuyển đổi giá trị trả về
        if (response.token) {
          this.cookieService.set('token', response.token);
          this.router.navigate(['/']);
          return true; // Trả về true nếu có token
        } else {
          // Xử lý trường hợp không có token trả về
          console.error('Login failed: No token returned from server');
          return false; // Trả về false nếu không có token
        }
      })
    );
  }


  logout() {
    this.cookieService.delete('token');
    this.router.navigate(['/login']);
  }

  get isAuthenticated(): boolean {
    const token = this.cookieService.get('token');
    return !!token && !this.jwtHelper.isTokenExpired(token);
  }

  get token(): string | null {
    return this.cookieService.get('token');
  }
}
