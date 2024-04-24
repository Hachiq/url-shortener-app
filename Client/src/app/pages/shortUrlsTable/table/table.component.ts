import { Component, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { ShortenedUrl } from 'src/app/models/shortened.url';
import { TokenService } from 'src/app/services/token.service';
import { UrlService } from 'src/app/services/url.service';

@Component({
  selector: 'app-table',
  templateUrl: './table.component.html',
  styleUrl: './table.component.scss'
})
export class TableComponent {

  displayedColumns: string[] = [ 'longUrl', 'shortUrl', 'delete' ];
  dataSource!: MatTableDataSource<ShortenedUrl>;

  @ViewChild(MatPaginator) paginator!: MatPaginator;

  constructor(private urlService: UrlService, public tokenService: TokenService){
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

  navigateToLongUrl(url: ShortenedUrl): void {
    window.location.href = url.longUrl;
  }

  delete(id: string) {
    this.urlService
      .delete(id)
      .subscribe(() => {
        this.loadUrls()
      }, (error) => {
        if (error.status === 400) {
          console.log("Something went wrong. Cannot delete.");
        }
      }
    );
  } 
}
