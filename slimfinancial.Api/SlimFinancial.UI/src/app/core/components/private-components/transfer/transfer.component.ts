import { Component, inject, Signal } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { ROUTER_OUTLET_DATA } from '@angular/router';
import { MaterialModule } from '../../../common/material/material.module';
import { transfer } from '../../../common/models/transfer';




@Component({
  selector: 'app-transfer',
  standalone: true,
  imports: [ReactiveFormsModule,MaterialModule],
  templateUrl: './transfer.component.html',
  styleUrl: './transfer.component.css'
})
export class TransferComponent {
  transferData = inject(ROUTER_OUTLET_DATA) as Signal<transfer>

 
 
  regularTransferForm = new FormGroup({
    TransferFrom : new FormControl(''),
    TransferTo : new FormControl('',[Validators.required]),
    Account : new FormControl('',[Validators.required]),
    Amount : new FormControl('',[Validators.required])
  })

  processTransaction() {
    console.log('from transfer:',this.transferData().source)
}
}
