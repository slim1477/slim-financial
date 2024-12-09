import { Component } from '@angular/core';
import {  RouterOutlet } from '@angular/router';
import { PublicModule } from './modules/public.module';
import { DashboardModule } from './modules/dashboard/dashboard.module';
// import { LoginComponent } from './core/login/login.component';





@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet,
  PublicModule,DashboardModule],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'slim-financial';


}
