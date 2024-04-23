import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { UrlToShorten } from '../interfaces/url.to.shorten';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs/internal/Observable';
import { ShortenedUrl } from '../models/shortened.url';

@Injectable({
  providedIn: 'root'
})
export class UrlService {

  constructor(private http: HttpClient) { }

  public get(): Observable<ShortenedUrl[]> {
    return this.http.get<ShortenedUrl[]>(
      `${environment.apiUrl}/Url/all`
    )
  }

  public shorten(url: UrlToShorten): Observable<any> {
    return this.http.post<any>(
      `${environment.apiUrl}/Url/shorten`,
      url
    );
  }
}
