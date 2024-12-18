import { Component, inject, Output, output, signal } from '@angular/core';
import { AccountService } from '../../../services/account.service';
import { WidgetComponent } from '../../../core/components/private-components/widget/widget.component';
import { MaterialModule } from '../../../core/common/material/material.module';
import {  RouterModule, Routes } from '@angular/router';
import { TransactionHistoryComponent } from '../../../core/components/private-components/transaction-history/transaction-history.component';
import { Account } from '../../../core/common/models/account';

interface accountLinks  {
  label : string;
  route : string;

}

@Component({
  selector: 'app-account',
  standalone: true,
  imports: [WidgetComponent,TransactionHistoryComponent,MaterialModule,RouterModule],
  providers:[AccountService,RouterModule],
  templateUrl: './account.component.html',
  styleUrl: './account.component.css'
})
export class AccountComponent {
accounts = inject(AccountService);
account = this.accounts.accounts().map(m => m.id);

currentAccount = signal(this.account[0])
transferRoute = `transfer/${this.currentAccount()}`
location = 'top'
links : accountLinks[]= [{
  label : 'Transaction History',
  route : 'history'
},
{
    label : 'overview',
    route : 'overview'
},
{
label : 'Transfer',
route : "transfer"
}
];



setCurrentAccount(acct: Account){
  this.currentAccount.set(acct.id)
  console.log(this.currentAccount(),this.links)
}

}
