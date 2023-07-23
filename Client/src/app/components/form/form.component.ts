import { Component, EventEmitter, Output } from '@angular/core';
import { Url } from 'src/app/models/url';
import { ShortenerService } from 'src/app/services/shortener.service';
import { TokenService } from 'src/app/services/token.service';
import { UrlService } from 'src/app/services/url.service';

@Component({
  selector: 'app-form',
  templateUrl: './form.component.html',
  styleUrls: ['./form.component.scss']
})
export class FormComponent {
  @Output() urlAdded: EventEmitter<any> = new EventEmitter<any>();
  newUrl: Url = { id: 0, shortUrl: '', longUrl: '', createdBy: '' };
  urls: Url[] = [];
  error: boolean = false;
  

constructor(private shortenerService: ShortenerService,
  private urlService: UrlService,
  private tokenService: TokenService){}

  ngOnInit(){
    this.loadUrls()
  }

  isAuthorizedUser(): boolean {
    const token = localStorage.getItem('userToken');
    if (token?.length === 0){
      return false;
    }
    return true;
  }

  loadUrls(): void{
    this.urlService
    .getUrls()
    .subscribe((result: Url[]) => this.urls = result)
  }

  checkUrlExists(longUrl: string): boolean {
    return this.urls.some(url => url.longUrl === longUrl);
  }

  onSubmit(): void {
    if(this.checkUrlExists(this.newUrl.longUrl)){
      this.error = true;
      return;
    }
    this.newUrl.shortUrl = this.shortenerService.generateShortUrl(this.newUrl.longUrl);
    this.newUrl.createdBy = this.tokenService.getUsernameFromToken();
    this.urlService
    .addUrl(this.newUrl)
    .subscribe(() => {
      this.urlAdded.emit(); // Refresh the table after adding a new URL
      this.newUrl = { id: 0, shortUrl: '', longUrl: '', createdBy: '' }; // Reset the form
    });
    this.error = false;
  }
}