import { Component, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
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

  @ViewChild(MatPaginator) paginator!: MatPaginator;

  constructor(private urlService: UrlService){
    this.loadUrls();
  }

  loadUrls() {
    this.urlService
      .get()
      .subscribe((result: ShortenedUrl[]) => { 
        this.dataSource = new MatTableDataSource<ShortenedUrl>(result);
        this.dataSource.paginator = this.paginator;
      } 
    );
  }
}
