import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MainComponent } from './modules/shared/layout/main/main.component';

const routes: Routes = [
  {
    path: '',
    component: MainComponent,
    children: [
      {
        path: '',
       loadChildren: () => import('@list/list.module').then(m => m.ListModule)
      },
      {
        path: 'Complete',
        loadChildren: () => import('@complete/complete.module').then(m => m.CompleteModule)
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
