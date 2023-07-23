import { Component } from '@angular/core';
import { ActivatedRoute} from '@angular/router';
import { Url } from 'src/app/models/url';
import { UrlService } from 'src/app/services/url.service';

@Component({
  selector: 'app-info',
  templateUrl: './info.component.html',
  styleUrls: ['./info.component.scss']
})
export class InfoComponent {
  url: Url = { id: 0, shortUrl: '', longUrl: '', createdBy: '' };

  constructor(private route: ActivatedRoute,
    private urlService: UrlService) {
    this.route.params.subscribe(params => {
      const id = +params['id'];
      this.urlService.getUrl(id).subscribe((result: Url) => this.url = result);
    });
  }
}
