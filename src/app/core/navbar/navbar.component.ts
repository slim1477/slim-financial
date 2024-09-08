import { Component, inject } from '@angular/core';
import { BreakpointObserver, Breakpoints } from '@angular/cdk/layout';
import { AsyncPipe, NgTemplateOutlet } from '@angular/common';
import { Observable } from 'rxjs';
import { map, shareReplay } from 'rxjs/operators';
import { MaterialModule } from '../common/material/material.module';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrl: './navbar.component.css',
  standalone: true,
  imports: [
  MaterialModule,
    AsyncPipe,
    NgTemplateOutlet
  ]
})
export class NavbarComponent {
  private breakpointObserver = inject(BreakpointObserver);
  navlinks: Array<string> = ['Accounts','Credit Cards','Mortgages','Loans','Investments','Rewards','Advise']

  isHandset$: Observable<boolean> = this.breakpointObserver.observe(Breakpoints.Handset)
    .pipe(
      map(result => result.matches),
      shareReplay()
    );
}
