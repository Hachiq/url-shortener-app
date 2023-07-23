import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TableComponent } from './components/table/table.component';
import { InfoComponent } from './components/info/info.component';

const routes: Routes = [
  { path: "table", component: TableComponent },
  { path: "info/:id", component: InfoComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
