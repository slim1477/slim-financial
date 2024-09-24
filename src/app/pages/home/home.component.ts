import { Component } from '@angular/core';
import { MaterialModule } from '../../core/common/material/material.module';
import { HelpComponent } from '../../core/home-page-sections/help/help.component';
import { HeroComponent } from '../../core/home-page-sections/hero/hero.component';
import { LocatorComponent } from '../../core/home-page-sections/locator/locator.component';
import { NavbarComponent } from '../../core/home-page-sections/navbar/navbar.component';
import { ProductsComponent } from '../../core/home-page-sections/products/products.component';
import { LinksComponent } from '../../core/home-page-sections/links/links.component';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [  MaterialModule,
    NavbarComponent,HeroComponent,
    ProductsComponent,
    HelpComponent,
    LocatorComponent,
    LinksComponent],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent {

  isOpen: boolean = false;

  handleIsOpen(e: boolean){
    this.isOpen = e;
    console.log(e);
  }
}
