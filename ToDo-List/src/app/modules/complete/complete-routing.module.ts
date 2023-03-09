import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CompleteModule } from './complete.module';
import { CompletePage } from './pages/complete/complete.page';

const routes: Routes = [
  {
    path: '',
    component:CompletePage
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CompleteRoutingModule { }
