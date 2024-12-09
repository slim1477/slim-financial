import { Component, computed, Input, Output, signal } from '@angular/core';
import { MaterialModule } from '../../common/material/material.module';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

export type dashboardMenuItem ={
  id: number;
  icon : string;
  label: string;
  route?: string;

}
@Component({
  selector: 'app-dashboard-nav',
  standalone: true,
  imports: [MaterialModule,CommonModule,RouterModule],
  templateUrl: './dashboard-nav.component.html',
  styleUrl: './dashboard-nav.component.css'
})
export class DashboardNavComponent {

  @Input()
  isOpened : boolean = false
  size = computed(() => this.isOpened ? '10rem' : '3rem');
  headerWidth = computed(() => this.isOpened ? '10rem' : '3rem')
  menuItem = signal<dashboardMenuItem[]>([
    {id: 1,icon:'analytics',label:'Overview',route:'overview'},
    {id: 2, icon:'analytics',label:'Accounts',route:'accounts'},
    {id: 3, icon:'person',label:'Profile',route:'profile'},
    {id: 4,icon:'analytics',label:'Transaction',route:'transaction'},
  ])
}
