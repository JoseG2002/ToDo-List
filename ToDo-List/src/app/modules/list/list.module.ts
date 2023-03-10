import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ListRoutingModule } from './list-routing.module';
import { ListPage } from './pages/list/list.page';


@NgModule({
  declarations: [
    ListPage
  ],
  imports: [
    CommonModule,
    ListRoutingModule
  ]
})
export class ListModule { }
