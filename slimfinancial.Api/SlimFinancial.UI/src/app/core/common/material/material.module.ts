import { NgModule } from '@angular/core';
import {MatToolbarModule} from '@angular/material/toolbar';
import {MatIconModule} from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatListModule } from '@angular/material/list';
import { MatMenuModule } from '@angular/material/menu';
import {MatDividerModule} from '@angular/material/divider';
import { FormsModule } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatCardModule } from '@angular/material/card';
import { MatGridListModule } from '@angular/material/grid-list';
import { MatTabGroup, MatTabsModule } from '@angular/material/tabs';
import { MatTableDataSource, MatTableModule } from '@angular/material/table';
import { MatSelectModule } from '@angular/material/select';
import { MatInputModule } from '@angular/material/input';
import { MatRadioButton, MatRadioGroup } from '@angular/material/radio';
import { MatPaginatorModule } from '@angular/material/paginator';


const material = [
  MatToolbarModule,
  MatIconModule,
  MatButtonModule,
  MatSidenavModule,
  MatListModule,
  MatMenuModule,
  MatDividerModule,
  FormsModule,
  MatFormFieldModule,
  MatCardModule,
  MatDividerModule,
  MatGridListModule,
  MatTabsModule,
  MatTabGroup,
  MatTableModule,
  MatSelectModule,
  MatInputModule,
  MatPaginatorModule
]

@NgModule({
  imports: [material, MatRadioButton, MatRadioGroup],
  exports:[material, MatRadioButton, MatRadioGroup]
})
export class MaterialModule { }
