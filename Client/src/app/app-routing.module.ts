import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginPageComponent } from './pages/login/login-page/login-page.component';
import { RegisterPageComponent } from './pages/register/register-page/register-page.component';
import { ShortUrlsTablePageComponent } from './pages/shortUrlsTable/short-urls-table-page/short-urls-table-page.component';
import { AboutPageComponent } from './pages/about/about-page/about-page.component';

const routes: Routes = [
  { path: '',   redirectTo: 'table', pathMatch: 'full' },
  { path: "table", component: ShortUrlsTablePageComponent },
  { path: "register", component: RegisterPageComponent },
  { path: "login", component: LoginPageComponent },
  { path: "about", component: AboutPageComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
