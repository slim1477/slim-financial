import { Component, computed, inject, input, OnInit, signal } from '@angular/core';
import { Router, RouterModule } from '@angular/router';
import { MaterialModule } from '../../../core/common/material/material.module';
import { FooterComponent } from '../../../core/components/shared/footer/footer.component';
import { AuthService } from '../../../services/auth.service';
import { Person } from '../../../core/common/models/person';
import { PersonService } from '../../../services/person.service';
import { dashboardMenuItem } from '../../../core/common/models/dashboardMenuItems';
import { SlicePipe } from '@angular/common';


@Component({
  selector: 'app-dashboard',
  standalone: true,
  imports: [MaterialModule, RouterModule, FooterComponent, SlicePipe],
  templateUrl: './dashboard.component.html',
  styleUrl: './dashboard.component.css'
})
export class DashboardComponent implements OnInit{
  authService = inject(AuthService);
  personService = inject(PersonService);
  route = inject(Router)
  authPerson = signal<Person>(Object())
  //isOpened = input<boolean>(false);
  size = computed(() => this.isOpened() ? '10rem' : '3rem');
  headerWidth = computed(() => this.isOpened() ? '10rem' : '3rem')
  menuItem = signal<dashboardMenuItem[]>([
    { id: 1, icon: 'analytics', label: 'Overview', route: 'overview' },
    { id: 2, icon: 'analytics', label: 'Accounts', route: 'accounts' },
    { id: 3, icon: 'person', label: 'Profile', route: 'profile' },
    { id: 4, icon: 'analytics', label: 'Transaction', route: 'transaction' },
  ])

  isOpened = signal<boolean>(true);
  btnClass = computed(() => !this.isOpened() ? 'is-flex is-justify-content-center' : 'is-flex is-justify-content-right')
  iconType = computed(() => this.isOpened() ? 'arrow_back' : 'menu')
  navWidth = computed(() => this.isOpened() ? '250px' : '64px');

  toggleIsOpened(){
    this.isOpened.set(!this.isOpened());
  }

  getAuthPersonData() {
    this.personService.getAuthPerson().subscribe({
      next: (response) => this.authPerson.set(response),
      error: (error) => console.log(error),
      complete: () => null
      }
    )
  }
  logout(){
    this.route.navigateByUrl('/home');
    this.authService.clearToken();
  }

  ngOnInit(): void {
    this.isOpened.set(false)
    this.getAuthPersonData();
  }
}
