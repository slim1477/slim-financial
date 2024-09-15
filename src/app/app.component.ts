import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { NavbarComponent } from './core/navbar/navbar.component';
import { HeroComponent } from './core/hero/hero.component';
import { MaterialModule } from './core/common/material/material.module';
import { ProductsComponent } from './core/products/products.component';





@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet,MaterialModule,NavbarComponent,HeroComponent,ProductsComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'slim-financial';

  isOpen: boolean = false;

  handleIsOpen(e: boolean){
    this.isOpen = e;
    console.log(e);
  }
}
