import { Component, inject, signal } from '@angular/core';
import { WidgetComponent } from '../../../core/components/private-components/widget/widget.component';
import { WidgetService } from '../../../services/widget.service';
import { WidgetOptionsComponent } from '../../../core/components/private-components/widget-options/widget-options.component';
import { MaterialModule } from '../../../core/common/material/material.module';

@Component({
  selector: 'app-overview',
  standalone: true,
  imports: [WidgetComponent,MaterialModule],
  providers:[WidgetService],
  templateUrl: './overview.component.html',
  styleUrl: './overview.component.css',

})
export class OverviewComponent {
  widgetStore = inject(WidgetService)
 
}
