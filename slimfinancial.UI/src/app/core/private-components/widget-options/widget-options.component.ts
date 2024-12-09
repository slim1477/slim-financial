import { Component, EventEmitter, Input, input, OnInit, Output, output } from '@angular/core';
import { MaterialModule } from '../../common/material/material.module';

@Component({
  selector: 'app-widget-options',
  standalone: true,
  imports: [MaterialModule],
  templateUrl: './widget-options.component.html',
  styleUrl: './widget-options.component.css'
})
export class WidgetOptionsComponent{

showOptions = input<boolean>() ;
showOptionsChange = output<boolean>()
backgroundColor = output<string>()

closeTab(){
  this.showOptionsChange.emit(!this.showOptions())
  console.log("I was clicked",this.backgroundColor)
}
changeBackgroundColor(color : string){
  this.backgroundColor.emit(color)
  console.log(this.backgroundColor)
}

}
