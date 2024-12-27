import { Component,ElementRef,input, OnInit, signal, viewChild } from '@angular/core';
import { WidgetService } from '../../../../services/widget.service';
import { MaterialModule } from '../../../common/material/material.module';
import { WidgetOptionsComponent } from '../widget-options/widget-options.component';
import { trigger, state, style, transition, animate } from '@angular/animations';
import Chart from 'chart.js/auto';



@Component({
  selector: 'app-widget',
  standalone: true,
  imports: [MaterialModule,WidgetOptionsComponent],
  providers: [WidgetService],
  templateUrl: './widget.component.html',
  styleUrl: './widget.component.css',
  animations: [
    trigger('showOptions', [
      state('false', style({
        transform: 'none'
      })),
      state('true', style(
        {transform: 'rotateY(180deg)'}
    )),
      // transition('true => false', animate('500ms ease-out')),
      transition('false <=> true', animate('500ms ease-in'))
    ])
  ]

})
export class WidgetComponent implements OnInit {
data = input.required();
location = input<string>()
component = input<string>()
chart = viewChild.required<ElementRef>('chart');

height = ''
backgroundColor = '';
showOptions = signal<boolean>(false)

showSelectedTab(){
  this.showOptions.set(!this.showOptions())
}

setBackgroundColor(color: string){
 this.backgroundColor = color;
}
setHeight(){
  switch(this.component()){
    case 'dashboard':
      this.height = this.location() === 'top' ? '30.52vh' : '55vh';
      break;
    case 'account':
      this.height = this.location() === 'top' ? '15.52vh' : '55vh';
      break;
    default:
      this.height = this.location() === 'top' ? '30.52vh' : '55vh';
  }
  
}
initializeChart(){
  new Chart(this.chart().nativeElement,{
    type: 'line',
    data: {
      labels:['Aug','Sep','Oct','Nov','Dec','Jan'],
      datasets: [{
        label:'Transactions',
        data: [100,102,105,110,115,120],
        borderColor: 'rgb(255,99,132,0.5)',
        fill: 'start'
      }],
    },
    options:{
      maintainAspectRatio: true,
      elements:{
        line:{
          tension: 0.4
        }
      }
    }
  })
}
ngOnInit(): void {
  // this.backgroundColor = "#a7c2e5";
  this.setHeight();
  this.initializeChart();
}
}

