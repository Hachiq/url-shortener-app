import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ShortenedUrlDetails } from 'src/app/models/shortened.url.details';
import { UrlService } from 'src/app/services/url.service';

@Component({
  selector: 'app-details-card',
  templateUrl: './details-card.component.html',
  styleUrl: './details-card.component.scss'
})
export class DetailsCardComponent {
  urlId!: string;

  shortenedUrl!: ShortenedUrlDetails;

  constructor (private route: ActivatedRoute, private urlService: UrlService) {
    route.params.subscribe(params => {
      this.urlId = params['id'];
    });
  }

  ngOnInit(){
    this.loadUrlDetails();
  }

  loadUrlDetails() {
    this.urlService
      .getById(this.urlId)
      .subscribe((result) => this.shortenedUrl = result);
  }
}
