import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { NavbarComponent } from './core/navbar/navbar.component';
import { HeroComponent } from './core/hero/hero.component';
import { MaterialModule } from './core/common/material/material.module';





@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet,NavbarComponent,HeroComponent,MaterialModule],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'slim-financial';

  isOpen: boolean = false;

  handleIsOpen(e: boolean){
    this.isOpen = e;
  }
}
