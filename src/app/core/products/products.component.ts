import { Component, OnInit } from '@angular/core';
import { MaterialModule } from '../common/material/material.module';

@Component({
  selector: 'app-products',
  standalone: true,
  imports: [MaterialModule],
  templateUrl: './products.component.html',
  styleUrl: './products.component.css'
})
export class ProductsComponent implements OnInit{

  expiryDate: string = "";

  ngOnInit(){
    const date = new Date();
    const month = date.getMonth() + 1;
    const fmt = new Intl.DateTimeFormat('en-US', { year: 'numeric', month: 'long', day: 'numeric' });
    date.setMonth(month);
    this.expiryDate = fmt.format(date);
  }
 
}
