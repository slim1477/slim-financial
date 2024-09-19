import { Component } from '@angular/core';
import { MaterialModule } from '../common/material/material.module';

@Component({
  selector: 'app-help',
  standalone: true,
  imports: [MaterialModule],
  templateUrl: './help.component.html',
  styleUrl: './help.component.css'
})
export class HelpComponent {

}
