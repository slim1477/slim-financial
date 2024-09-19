import { Component } from '@angular/core';
import { MaterialModule } from '../common/material/material.module';


@Component({
  selector: 'app-links',
  standalone: true,
  imports: [MaterialModule],
  templateUrl: './links.component.html',
  styleUrl: './links.component.css'
})
export class LinksComponent {

}
