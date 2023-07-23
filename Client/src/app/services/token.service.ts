import { Injectable } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import jwtDecode from 'jwt-decode';

@Injectable({
  providedIn: 'root'
})
export class TokenService {

  constructor(private route: ActivatedRoute) { }

  public getToken(): void{
    this.route.queryParams.subscribe(params => {
      const token = params['token'];
      localStorage.setItem('userToken', token)
    })
  }

  public getUsernameFromToken(): string {
    const token = localStorage.getItem('userToken');
    if (token) {
      const decodedToken = jwtDecode<any>(token);
      return decodedToken['http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name'];
    }
    return '';
  }

  public getRoleFromToken(): string {
    const token = localStorage.getItem('userToken');
    if (token) {
      const decodedToken = jwtDecode<any>(token);
      return decodedToken['http://schemas.microsoft.com/ws/2008/06/identity/claims/role'];
    }
    return '';
  }
}
