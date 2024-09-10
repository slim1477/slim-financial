import { NgModule } from '@angular/core';
import {MatToolbarModule} from '@angular/material/toolbar';
import {MatIconModule} from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatListModule } from '@angular/material/list';
import { MatMenuModule } from '@angular/material/menu';
import {MatDividerModule} from '@angular/material/divider';


const material = [
  MatToolbarModule,
  MatIconModule,
  MatButtonModule,
  MatSidenavModule,
  MatListModule,
  MatMenuModule,
  MatDividerModule
]

@NgModule({
  imports: [material],
  exports:[material]
})
export class MaterialModule { }
