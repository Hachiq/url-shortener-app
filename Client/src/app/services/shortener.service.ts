import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ShortenerService {

  private b62: string = '0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ';

  constructor() { }

  public generateShortUrl(longUrl: string): string {
    let hash = '';
    for (let i = 0; i < 8; i++) {
      hash += this.b62.charAt(this.getRandomInt(0, this.b62.length));
    }

    const urlParts = longUrl.split('/');
    const domain = urlParts[2];
    return `${urlParts[0]}//${domain}/${hash}`;
  }

  private getRandomInt(min: number, max: number): number {
    return Math.floor(Math.random() * (max - min)) + min;
  }
}
