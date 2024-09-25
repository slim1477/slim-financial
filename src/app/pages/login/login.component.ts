import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { MaterialModule } from '../../core/common/material/material.module';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [FormsModule,MaterialModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent implements OnInit{

  show: boolean = false;
  top: string = "";
 

  showCreds(){
    this.show = !this.show
     return this.top = this.show ? "0%" : "-54.5%";
  }

  ngOnInit(): void {
    this.top = "-54.4%";
  }

}
