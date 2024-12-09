import { computed, Injectable, signal } from '@angular/core';
import { WidgetData } from '../core/common/models/widget';
import { WidgetComponent } from '../core/private-components/widget/widget.component';


enum reportPeriod {
  week,
  month,
  year 
}
@Injectable()
export class WidgetService {
 
  widgets = signal<WidgetData[]>([
    {
      id:1,
      label: "Test widget",
      period: reportPeriod.month.toString(),
      content: WidgetComponent
    },
    {
      id:2,
      label: "Test widget2",
      period: reportPeriod.week.toString(),
      content: WidgetComponent
    },
    {
      id:3,
      label: "Test widget3",
      period: reportPeriod.year.toString(),
      content: WidgetComponent
    },
    {
      id:4,
      label: "Test widget4",
      period: reportPeriod.year.toString(),
      content: WidgetComponent
    }

  
  ]);
  

  addedWidgets = signal<WidgetData[]>([]);
  setBackGroundColor(id: number, color:string){
    const widget  = this.widgets().find(w => w.id === id)
    console.log("I was clicked");
    return widget;
   }
  constructor() { }
}
