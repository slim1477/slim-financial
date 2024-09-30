import { Component } from '@angular/core';
import { MaterialModule } from '../../common/material/material.module';

@Component({
  selector: 'app-hero',
  standalone: true,
  imports: [MaterialModule],
  templateUrl: './hero.component.html',
  styleUrl: './hero.component.css'
})
export class HeroComponent {

}
