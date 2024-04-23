import { Component } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-register-form',
  templateUrl: './register-form.component.html',
  styleUrl: './register-form.component.scss'
})
export class RegisterFormComponent {
  
  constructor(private router: Router, private authService: AuthService){}
  
  hide = true;

  username = new FormControl('', [Validators.required, Validators.minLength(4), Validators.maxLength(50)]);
  password = new FormControl('', [Validators.required, Validators.minLength(6)]);

  register(){
    this.authService.register({
      username: this.username.value,
      password: this.password.value
    }).subscribe(() => {
      this.router.navigate(['login']);
    },
      (error) => {
        if (error.status === 409){
          this.username.setErrors({ conflict: true });
        }
        else {
          console.log('Undefined error. Please, try again later.');
        }
      }
    );
  }

  getUsernameErrorMessage() {
    if (this.username.hasError('required')) {
      return 'You must enter a value';
    }

    if (this.username.hasError('conflict')) {
      return 'Username is taken';
    }

    if (this.username.hasError('minlength')){
      return 'Name too short';
    }

    if (this.username.hasError('maxlength')){
      return 'Name too long';
    }
    
    return '';
  }

  getPasswordErrorMessage() {
    if (this.password.hasError('required')) {
      return 'You must enter a value';
    }

    return this.password.hasError('minlength') ? 'Password too short' : '';
  }
}
