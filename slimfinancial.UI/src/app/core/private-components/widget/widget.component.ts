import { Component, computed, inject, input, OnInit, signal } from '@angular/core';

import { WidgetService } from '../../../services/widget.service';
import { MaterialModule } from '../../common/material/material.module';
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
height = ''
backgroundColor = '';
showOptions = signal<boolean>(false)

showSelectedTab(){
  this.showOptions.set(!this.showOptions())
}

setBackgroundColor(color: string){
 this.backgroundColor = color;
 console.log('222',color)
}

ngOnInit(): void {
  this.backgroundColor = "#a7c2e5";
  this.height =  this.location() === 'top' ? '225px' : '320px';
}
}

