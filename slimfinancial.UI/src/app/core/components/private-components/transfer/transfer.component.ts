import { Component, inject, input, signal } from '@angular/core';

import { FormControl, FormGroup,ReactiveFormsModule,Validators } from '@angular/forms';
import { MaterialModule } from '../../../common/material/material.module';
import { ROUTER_CONFIGURATION } from '@angular/router';




@Component({
  selector: 'app-transfer',
  standalone: true,
  imports: [ReactiveFormsModule,MaterialModule],
  templateUrl: './transfer.component.html',
  styleUrl: './transfer.component.css'
})
export class TransferComponent {
  accountNumber = input()
 
  regularTransferForm = new FormGroup({
    TransferFrom : new FormControl(''),
    TransferTo : new FormControl('',[Validators.required]),
    Account : new FormControl('',[Validators.required]),
    Amount : new FormControl('',[Validators.required])
  })


}
