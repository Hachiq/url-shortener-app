import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { UrlToShorten } from '../interfaces/url.to.shorten';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs/internal/Observable';
import { ShortenedUrl } from '../models/shortened.url';
import { ShortenedUrlDetails } from '../models/shortened.url.details';

@Injectable({
  providedIn: 'root'
})
export class UrlService {

  constructor(private http: HttpClient) { }

  public get(): Observable<ShortenedUrl[]> {
    return this.http.get<ShortenedUrl[]>(
      `${environment.apiUrl}/Url/all`
    );
  }

  public getById(id: string): Observable<ShortenedUrlDetails> {
    return this.http.get<ShortenedUrlDetails>(
      `${environment.apiUrl}/Url/${id}`
    );
  }

  public shorten(url: UrlToShorten): Observable<any> {
    return this.http.post<any>(
      `${environment.apiUrl}/Url/shorten`,
      url
    );
  }

  public delete(id: string): Observable<any> {
    return this.http.delete<any>(
      `${environment.apiUrl}/Url/${id}/delete`
    );
  }
}
