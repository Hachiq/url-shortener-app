import { Component } from '@angular/core';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-short-urls-table-page',
  templateUrl: './short-urls-table-page.component.html',
  styleUrl: './short-urls-table-page.component.scss'
})
export class ShortUrlsTablePageComponent {

  constructor(public authService: AuthService) { }
  
}
