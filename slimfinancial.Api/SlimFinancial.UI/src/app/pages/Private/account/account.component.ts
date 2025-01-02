
import { CurrencyPipe } from '@angular/common';
import { Component, inject, OnInit, signal } from '@angular/core';
import { RouterModule } from '@angular/router';
import { MaterialModule } from '../../../core/common/material/material.module';
import { Account } from '../../../core/common/models/account';
import { AccountService } from '../../../services/account.service';
import { HttpErrorResponse } from '@angular/common/http';
import { transfer } from '../../../core/common/models/transfer';


interface accountLinks {
  label: string;
  route: string;
}
@Component({
  selector: 'app-account',
  standalone: true,
  imports: [MaterialModule, RouterModule, CurrencyPipe],
  providers: [AccountService, RouterModule],
  templateUrl: './account.component.html',
  styleUrl: './account.component.css',
})

// Represents the account page for user dashboard
export class AccountComponent implements OnInit {
  service = inject(AccountService);
  accounts = signal<Account[]>([])
  currentAccount = signal<Account>(Object());
  errorMessage = signal<HttpErrorResponse>(Object())
  transferData = signal<transfer>(Object())

  links: accountLinks[] = [{
    label: 'Transaction History',
    route: 'history'
  },
  {
    label: 'Details',
    route: 'details'
  },
  {
    label: 'Transfer',
    route: "transfer"
  }
  ];

  // Gets all accounts for the signed on user
  onGetAccount() {
    this.service.getAccounts().subscribe({
      next: (response) => { this.accounts.set(response), this.service.setAccounts(response) },
      error: (error) => this.errorMessage.set(error),
      complete: () => {
        this.currentAccount.set(this.accounts()[0]),
          this.setCurrentAccount(this.accounts()[0]),
          this.transferData.set({
            source: this.currentAccount(),
            destination: this.accounts().filter(x => x.accountNumber != this.currentAccount().accountNumber)
            })
      }
    })
  }

  // sets the current account that is in user view
  setCurrentAccount(acct: Account) {
    this.transferData.update(data => ({
      ...data,
      source: acct ,
      destination: this.accounts()
        .map(acct => acct).filter(x => x.accountNumber != acct.accountNumber)
    }));
    const act = this.accounts().find(x => x.accountNumber == acct.accountNumber)
    if (act != null) act.isCurrent = true
    this.accounts().filter(x => x.accountNumber != acct.accountNumber).map(y => y.isCurrent = false)
    this.currentAccount.set(acct)
  }


  ngOnInit(): void {
    this.onGetAccount()
    this.service.getTransactions(this.currentAccount())
  }

}






