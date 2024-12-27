import { Component, inject, input, Signal, signal } from '@angular/core';

import { FormControl, FormGroup,ReactiveFormsModule,Validators } from '@angular/forms';
import { MaterialModule } from '../../../common/material/material.module';
import { ROUTER_CONFIGURATION, ROUTER_OUTLET_DATA } from '@angular/router';

interface transfer{
  source: number,
  destination : number[]
}


@Component({
  selector: 'app-transfer',
  standalone: true,
  imports: [ReactiveFormsModule,MaterialModule],
  templateUrl: './transfer.component.html',
  styleUrl: './transfer.component.css'
})
export class TransferComponent {
  transferData = inject(ROUTER_OUTLET_DATA) as Signal<transfer>
//  test = this.transferData() as transfer
 
 
  regularTransferForm = new FormGroup({
    TransferFrom : new FormControl(''),
    TransferTo : new FormControl('',[Validators.required]),
    Account : new FormControl('',[Validators.required]),
    Amount : new FormControl('',[Validators.required])
  })

showData(){
  console.log(this.transferData())
}
show(){
  console.log(this.regularTransferForm.value)
}
}
