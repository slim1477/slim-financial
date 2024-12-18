import { Component,input, OnInit, signal } from '@angular/core';
import { WidgetService } from '../../../../services/widget.service';
import { MaterialModule } from '../../../common/material/material.module';
import { NgComponentOutlet } from '@angular/common';
import { WidgetOptionsComponent } from '../widget-options/widget-options.component';
import { trigger, state, style, transition, animate } from '@angular/animations';



@Component({
  selector: 'app-widget',
  standalone: true,
  imports: [MaterialModule,NgComponentOutlet,WidgetOptionsComponent],
  providers: [WidgetService],
  templateUrl: './widget.component.html',
  styleUrl: './widget.component.css',
  animations: [
    trigger('showOptions', [
      state('true', style({
        transform: 'rotateY(179deg)'
      })),
      state('false', style({
        transform: 'rotateY(0)'
      })),
      transition('true => false', animate('500ms ease-out')),
      transition('false => true', animate('500ms ease-in'))
    ])
  ]

})
export class WidgetComponent implements OnInit {
data = input.required();
location = input<string>()
component = input<string>()

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

ngOnInit(): void {
  this.backgroundColor = "#a7c2e5";
  this.setHeight();
}
}

