import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CompleteRoutingModule } from './complete-routing.module';
import { CompletePage } from './pages/complete/complete.page';


@NgModule({
  declarations: [
    CompletePage
  ],
  imports: [
    CommonModule,
    CompleteRoutingModule
  ]
})
export class CompleteModule { }
