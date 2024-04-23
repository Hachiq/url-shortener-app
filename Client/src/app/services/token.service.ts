import { Injectable } from '@angular/core';
import { AuthService } from './auth.service';
import { jwtDecode } from 'jwt-decode';

@Injectable({
  providedIn: 'root'
})
export class TokenService {

  constructor(private authService: AuthService) { }

  public getUsernameFromToken(): string {
    const token = this.authService.getToken();
    if (token) {
      const decodedToken = jwtDecode<any>(token);
      return decodedToken['http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name'];
    }
    return '';
  }
}
