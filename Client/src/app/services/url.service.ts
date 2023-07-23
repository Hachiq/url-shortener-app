import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Url } from '../models/url';
import { Observable } from 'rxjs/internal/Observable';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class UrlService {

  private url = "Url";

  constructor(private http: HttpClient) { }

  public getUrls() : Observable<Url[]>{
    return this.http.get<Url[]>(
      `${environment.apiUrl}/${this.url}`
    )
  }

  public getUrl(id: number) : Observable<Url>{
    console.log(`${environment.apiUrl}/${this.url}/${id}`)
    return this.http.get<Url>(
      `${environment.apiUrl}/${this.url}/${id}`
    )
  }

  public addUrl(url: Url): Observable<Url[]>{
    return this.http.post<Url[]>(
      `${environment.apiUrl}/${this.url}`,
      url
    );
  }

  public deleteUrl(id: number): Observable<Url[]>{
    return this.http.delete<Url[]>(
      `${environment.apiUrl}/${this.url}/${id}`
    );
  }
}
