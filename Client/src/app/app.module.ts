import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { AuthInterceptor } from './services/auth.interceptor';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';

import { MatToolbarModule } from '@angular/material/toolbar';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatTableModule } from '@angular/material/table';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatCardModule } from '@angular/material/card';

import { AppComponent } from './app.component';
import { HeaderComponent } from './layout/header/header.component';
import { LoginFormComponent } from './pages/login/login-form/login-form.component';
import { LoginPageComponent } from './pages/login/login-page/login-page.component';
import { RegisterPageComponent } from './pages/register/register-page/register-page.component';
import { RegisterFormComponent } from './pages/register/register-form/register-form.component';
import { ShortUrlsTablePageComponent } from './pages/shortUrlsTable/short-urls-table-page/short-urls-table-page.component';
import { TableComponent } from './pages/shortUrlsTable/table/table.component';
import { AddSectionComponent } from './pages/shortUrlsTable/add-section/add-section.component';
import { ShortUrlInfoPageComponent } from './pages/shortUrlInfo/short-url-info-page/short-url-info-page.component';
import { DetailsCardComponent } from './pages/shortUrlInfo/details-card/details-card.component';
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
    TableComponent,
    AddSectionComponent,

    ShortUrlInfoPageComponent,
    DetailsCardComponent,

    AboutPageComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,

    MatToolbarModule,
    MatButtonModule,
    MatIconModule,
    MatInputModule,
    MatFormFieldModule,
    MatTableModule,
    MatPaginatorModule,
    MatCardModule
  ],
  providers: [
    provideAnimationsAsync(),
    {
      provide: HTTP_INTERCEPTORS,
      useClass: AuthInterceptor,
      multi: true
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
