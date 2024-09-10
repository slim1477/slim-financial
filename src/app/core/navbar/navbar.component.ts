import { Component, EventEmitter, inject, Input, Output } from '@angular/core';
import { BreakpointObserver, Breakpoints } from '@angular/cdk/layout';
import { AsyncPipe, NgTemplateOutlet } from '@angular/common';
import { Observable } from 'rxjs';
import { map, shareReplay } from 'rxjs/operators';
import { MaterialModule } from '../common/material/material.module';
import { HeroComponent } from '../hero/hero.component';
import { RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrl: './navbar.component.css',
  standalone: true,
  imports: [
  MaterialModule,
    AsyncPipe,
    NgTemplateOutlet,
    HeroComponent,
    RouterOutlet
  ]
})
export class NavbarComponent {
  private breakpointObserver = inject(BreakpointObserver);
  
  @Input()
  btnClicked : boolean = false;
  
  @Output()
  Clicked: EventEmitter<boolean> = new EventEmitter<boolean>();


  isHandset$: Observable<boolean> = this.breakpointObserver.observe(Breakpoints.Handset)
    .pipe(
      map(result => result.matches),
      shareReplay()
    );

    // handles hamburger button click event
    handleBtnClick(){
      this.btnClicked = this.btnClicked ? false : true;
      if(this.isHandset$){
        this.Clicked.emit(this.btnClicked);
      }
      
     
    }
}
