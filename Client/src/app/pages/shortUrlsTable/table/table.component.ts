import { Component } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { ShortenedUrl } from 'src/app/models/shortened.url';
import { UrlService } from 'src/app/services/url.service';

@Component({
  selector: 'app-table',
  templateUrl: './table.component.html',
  styleUrl: './table.component.scss'
})
export class TableComponent {
  displayedColumns: string[] = [ 'longUrl', 'shortUrl' ];
  dataSource!: MatTableDataSource<ShortenedUrl>;

  constructor(private urlService: UrlService){
    this.loadUrls();
  }

  loadUrls() {
    this.urlService
      .get()
      .subscribe((result: ShortenedUrl[]) => { 
        this.dataSource = new MatTableDataSource<ShortenedUrl>(result);
      } 
    );
  }
}
