import { Component } from '@angular/core';
import { MaterialModule } from '../../../core/common/material/material.module';
import { HelpComponent } from '../../../core/public-components/help/help.component';
import { HeroComponent } from '../../../core/public-components/hero/hero.component';
import { LinksComponent } from '../../../core/public-components/links/links.component';
import { LocatorComponent } from '../../../core/public-components/locator/locator.component';
import { NavbarComponent } from '../../../core/public-components/navbar/navbar.component';
import { ProductsComponent } from '../../../core/public-components/products/products.component';


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
