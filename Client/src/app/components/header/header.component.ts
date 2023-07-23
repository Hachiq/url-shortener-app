import { Component } from '@angular/core';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent {

constructor(){}

  onRedirect(): void {
    window.location.href = 'https://localhost:7027';
  }
}
