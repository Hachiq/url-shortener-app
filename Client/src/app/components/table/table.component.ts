import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { Url } from 'src/app/models/url';
import { TokenService } from 'src/app/services/token.service';
import { UrlService } from 'src/app/services/url.service';

@Component({
  selector: 'app-table',
  templateUrl: './table.component.html',
  styleUrls: ['./table.component.scss']
})
export class TableComponent {
  urls: Url[] = [];

  constructor(private urlService: UrlService,
    private tokenService: TokenService,
    private router: Router){}

  ngOnInit(): void {
    this.loadUrls();
  }

  handleUrlAdded(): void {
    this.loadUrls();
  }

  loadUrls(): void{
    this.urlService
    .getUrls()
    .subscribe((result: Url[]) => this.urls = result)
  }

  navigateToLongUrl(url: Url): void {
    window.location.href = url.longUrl;
  }

  goToUrlInfo(id: number) {
    this.router.navigate(['/info', id]);
  }

  getDisplayNumber(index: number): number {
    return index + 1;
  }

  onDelete(id: number): void {
    this.urlService
    .deleteUrl(id)
    .subscribe(() => this.loadUrls())
  }

  canDelete(url: Url): boolean {
    if(url.createdBy == this.tokenService.getUsernameFromToken() || this.tokenService.getRoleFromToken() == 'Admin'){
      return true;
    }
    return false;
  }

  isAuthorized(): boolean {
    const token = localStorage.getItem('userToken')
    if(token){
      return true;
    }
    return false;
  }
}
