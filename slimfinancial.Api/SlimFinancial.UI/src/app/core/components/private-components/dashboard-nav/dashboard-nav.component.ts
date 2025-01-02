import { CommonModule } from '@angular/common';
import { Component, computed, input, OnInit, signal } from '@angular/core';
import { RouterModule } from '@angular/router';
import { MaterialModule } from '../../../common/material/material.module';
import { dashboardMenuItem } from '../../../common/models/dashboardMenuItems';
import { Person } from '../../../common/models/person';


@Component({
  selector: 'app-dashboard-nav',
  standalone: true,
  imports: [MaterialModule, CommonModule, RouterModule],
  templateUrl: './dashboard-nav.component.html',
  styleUrl: './dashboard-nav.component.css'
})
export class DashboardNavComponent implements OnInit {

  person = input.required<Person>()
  initials = signal<string>('')

  isOpened = input<boolean>(false);
  size = computed(() => this.isOpened() ? '10rem' : '3rem');
  headerWidth = computed(() => this.isOpened() ? '10rem' : '3rem')
  menuItem = signal<dashboardMenuItem[]>([
    {id: 1,icon:'analytics',label:'Overview',route:'overview'},
    {id: 2, icon:'analytics',label:'Accounts',route:'accounts'},
    {id: 3, icon:'person',label:'Profile',route:'profile'},
    {id: 4,icon:'analytics',label:'Transaction',route:'transaction'},
  ])

  setInitials() {
    //if (this.person()) {
    //  console.log('person has been loaded:',this.person())
    //}
    console.log('from setinitials:',this.person())
    const initial = this.person() !== null || undefined ? this.person().fname[0] + this.person().lname[0] : ''
    this.initials.set(initial.toUpperCase());
  }

  ngOnInit() {
    if (this.person() != null || undefined) {
      this.setInitials()
    } else {
      console.log('person is empty')
    }
    
    //console.log('I am from nav',this.person())
  }
}
