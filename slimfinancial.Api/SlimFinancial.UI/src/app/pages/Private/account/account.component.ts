
import { AccountService } from '../../../services/account.service';
import { MaterialModule } from '../../../core/common/material/material.module';
import { Account } from '../../../core/common/models/account';
import { RouterModule } from '@angular/router';
import { Component,inject, OnInit, signal } from '@angular/core';
import { CurrencyPipe } from '@angular/common';


interface accountLinks {
  label: string;
  route: string;
}
interface transfer {
  source: string,
  destination: string[]
}
@Component({
  selector: 'app-account',
  standalone: true,
  imports: [MaterialModule, RouterModule, CurrencyPipe],
  providers: [AccountService, RouterModule],
  templateUrl: './account.component.html',
  styleUrl: './account.component.css',
})
export class AccountComponent implements OnInit {
  service = inject(AccountService);
  accounts: Account[] = []
  account = this.accounts.map(m => m.accountNumber);
  currentAccount = signal(this.account[0]);
  isClicked = signal(false)
  errorMessage = ''
  transferData = signal<transfer>({
    source: this.currentAccount(),
    destination: this.account.filter(x => x != this.currentAccount())
  })

  links: accountLinks[] = [{
    label: 'Transaction History',
    route: 'history'
  },
  {
    label: 'overview',
    route: 'overview'
  },
  {
    label: 'Transfer',
    route: "transfer"
  }
  ];

  onGetAccount() {
    this.service.getAccounts().subscribe(
      {
        next:(response) => this.accounts = response,
        error: (error) =>  console.log(error)
        
      }
      )
  }

  checkIsActive(index: number = 0) {
    const t = this.accounts.map(x => x.accountNumber)
    let currentIndex = t.indexOf(this.currentAccount());
    if(t.length < 1){
      return true
    }
    return currentIndex == index
  }
  setCurrentAccount(acct: string) {
    this.transferData().source = acct
    this.transferData().destination = this.accounts
      .map(acct => acct.accountNumber).filter(x => x != acct)
    this.isClicked.set(!this.isClicked())
    this.currentAccount.set(acct)
  }
 getTime(){
  const start = Date.now();
  console.log(this.accounts,Date.now() - start)
 }
  ngOnInit(): void {
    this.onGetAccount()
    this.checkIsActive()
      this.currentAccount.set(this.account[0])
   
  }

}






