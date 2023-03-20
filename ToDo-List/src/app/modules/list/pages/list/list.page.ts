import { OnInit } from '@angular/core';
import { Component } from '@angular/core';
import { List } from 'src/app/Models/list';
import { ListService } from 'src/app/Services/list.service';

@Component({
  selector: 'app-list',
  templateUrl: './list.page.html',
  styleUrls: ['./list.page.css']
})
export class ListPage implements OnInit {
  public lists: List[];
  
  constructor(private listService: ListService){
    this.lists = [];
  }

  public ngOnInit(): void{
    this.listService.list().subscribe(data => {
      this.lists = data;
    })
  }
}
