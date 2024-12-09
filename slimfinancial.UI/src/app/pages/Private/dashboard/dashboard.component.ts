import { Component, computed, signal } from '@angular/core';
import { MaterialModule } from '../../../core/common/material/material.module';
import { RouterModule } from '@angular/router';
import { DashboardNavComponent } from '../../../core/private-components/dashboard-nav/dashboard-nav.component';
import { FooterComponent } from '../../../core/shared/footer/footer.component';


@Component({
  selector: 'app-dashboard',
  standalone: true,
  imports: [MaterialModule,RouterModule,DashboardNavComponent,FooterComponent],
  templateUrl: './dashboard.component.html',
  styleUrl: './dashboard.component.css'
})
export class DashboardComponent {

  isOpened = signal<boolean>(true);
  btnClass = computed(() => !this.isOpened() ? 'is-flex is-justify-content-center' : 'is-flex is-justify-content-right')
  iconType = computed(() => this.isOpened() ? 'arrow_back' : 'menu')
  navWidth = computed(() => this.isOpened() ? '250px' : '64px');

  toggleIsOpened(){
    this.isOpened.set(!this.isOpened());
  }
}
