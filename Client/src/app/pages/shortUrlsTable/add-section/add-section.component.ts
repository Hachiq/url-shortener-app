import { Component } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { TokenService } from 'src/app/services/token.service';
import { UrlService } from 'src/app/services/url.service';

@Component({
  selector: 'app-add-section',
  templateUrl: './add-section.component.html',
  styleUrl: './add-section.component.scss'
})
export class AddSectionComponent {

  constructor(private urlService: UrlService, private tokenService: TokenService) {}

  url = new FormControl('', [Validators.required]);

  shorten(){
    this.urlService.shorten({
      url: this.url.value,
      username: this.tokenService.getUsernameFromToken()
    }).subscribe(() => { },
      (error) => {
        if (error.status === 400){
          const reason = error.error.reason;
          if (reason === 'InvalidUrl') {
            this.url.setErrors({ invalidUrl: true });
            
          }
          else if (reason === "NoCreator") {
            this.url.setErrors({ noCreator: true });
          }
        }
        else if (error.status === 401) {
          this.url.setErrors({ unauthorized: true })
        }
        else {
          console.log('Undefined error. Please, try again later.');
        }
      }
    )
  }

  getUrlErrorMessage() {
    if (this.url.hasError('required')) {
      return 'You must enter a value';
    }

    if (this.url.hasError('unauthorized')){
      return 'Please, log in before shortening';
    }

    if (this.url.hasError('invalidUrl')) {
      return 'URL is invalid';
    }

    if (this.url.hasError('noCreator')) {
      return 'Creator not specified';
    }
    
    return '';
  }
}
