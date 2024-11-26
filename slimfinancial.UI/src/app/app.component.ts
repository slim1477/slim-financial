import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';

import { HomeComponent } from './pages/home/home.component';
import { PublicPagesModule } from './modules/publicpages.module';
// import { LoginComponent } from './core/login/login.component';





@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet,
  PublicPagesModule],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'slim-financial';


}
