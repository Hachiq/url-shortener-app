import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';

import { MatToolbarModule } from '@angular/material/toolbar';

import { AppComponent } from './app.component';
import { HeaderComponent } from './layout/header/header.component';
import { LoginFormComponent } from './pages/login/login-form/login-form.component';
import { LoginPageComponent } from './pages/login/login-page/login-page.component';
import { RegisterPageComponent } from './pages/register/register-page/register-page.component';
import { RegisterFormComponent } from './pages/register/register-form/register-form.component';
import { ShortUrlsTablePageComponent } from './pages/shortUrlsTable/short-urls-table-page/short-urls-table-page.component';
import { ShortUrlInfoPageComponent } from './pages/shortUrlInfo/short-url-info-page/short-url-info-page.component';
import { AboutPageComponent } from './pages/about/about-page/about-page.component';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    LoginPageComponent,
    LoginFormComponent,
    RegisterPageComponent,
    RegisterFormComponent,
    ShortUrlsTablePageComponent,
    ShortUrlInfoPageComponent,
    AboutPageComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,

    MatToolbarModule
  ],
  providers: [
    provideAnimationsAsync()
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
