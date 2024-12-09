import { Component, inject, signal } from '@angular/core';
import { WidgetComponent } from '../../../core/private-components/widget/widget.component';

import { WidgetService } from '../../../services/widget.service';
import { WidgetData } from '../../../core/common/models/widget';
import { trigger, state, style, transition, animate } from '@angular/animations';
import { WidgetOptionsComponent } from '../../../core/private-components/widget-options/widget-options.component';
import { MaterialModule } from '../../../core/common/material/material.module';

@Component({
  selector: 'app-overview',
  standalone: true,
  imports: [WidgetComponent,WidgetOptionsComponent,MaterialModule],
  providers:[WidgetService],
  templateUrl: './overview.component.html',
  styleUrl: './overview.component.css',

})
export class OverviewComponent {
location = ''
  widgetStore = inject(WidgetService)
 
}
