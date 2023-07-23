import { Component } from '@angular/core';
import { Url } from 'src/app/models/url';
import { UrlService } from 'src/app/services/url.service';

@Component({
  selector: 'app-table',
  templateUrl: './table.component.html',
  styleUrls: ['./table.component.scss']
})
export class TableComponent {
  urls: Url[] = [];

  constructor(private urlService: UrlService){}

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

  getDisplayNumber(index: number): number {
    return index + 1;
  }

  onDelete(id: number): void {
    this.urlService
    .deleteUrl(id)
    .subscribe(() => this.loadUrls())
  }
}
