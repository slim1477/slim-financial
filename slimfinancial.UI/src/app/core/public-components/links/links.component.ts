import { Component } from '@angular/core';
import { MaterialModule } from '../../common/material/material.module';
import { FooterComponent } from '../../shared/footer/footer.component';


@Component({
  selector: 'app-links',
  standalone: true,
  imports: [MaterialModule,FooterComponent],
  templateUrl: './links.component.html',
  styleUrl: './links.component.css'
})
export class LinksComponent {

}
