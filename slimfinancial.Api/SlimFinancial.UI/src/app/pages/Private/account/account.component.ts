
import { CurrencyPipe, formatDate } from '@angular/common';
import { AfterViewInit, Component, inject, OnInit, signal, ViewChild } from '@angular/core';
import { RouterModule } from '@angular/router';
import { MaterialModule } from '../../../core/common/material/material.module';
import { Account } from '../../../core/common/models/account';
import { AccountService } from '../../../services/account.service';
import { HttpErrorResponse } from '@angular/common/http';
import { transfer } from '../../../core/common/models/transfer';
import { Transaction } from '../../../core/common/models/transaction';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';


interface accountLinks {
  id: number;
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
  //transactions = signal<Transaction[]>([])
  transactions: Transaction[] = []
  showHistory = signal<boolean>(true)
  source = new MatTableDataSource<Transaction>(this.transactions);
  @ViewChild(MatPaginator) paginator: MatPaginator;

  links: accountLinks[] = [
    {
    id: 1,
    label: 'Details',
    route: 'details'
  },
    {
    id: 2,
    label: 'Transfer',
    route: "transfer"
  }
  ];

  // ==========================

  tableHeaders = ['Date', 'Description', 'Amount', 'Balance']

  tableHeader = [
    //{
    //  columnDef: 'ID',
    //  header: '#',
    //  cell: (element: Transaction) => `${element.id}`,
    //},
    {
      columnDef: 'Date',
      header: 'Date',
      cell: (element: Transaction) => `${formatDate(element.date, "dd/MM/yyyy", 'en-US')}`,
    },
    {
      columnDef: 'Description',
      header: 'Description',
      cell: (element: Transaction) => `${element.description}`,
    },
    {
      columnDef: 'Amount',
      header: 'Amount',
      cell: (element: Transaction) => `${element.amount}`,
    },
    {
      columnDef: 'Balance',
      header: 'Balance',
      cell: (element: Transaction) => `${element.balance}`,
    },
  ]

  // ==========================
  toggleShowHistory(id: number) {
    
    if (id > 0) {
      this.showHistory.set(false)
      console.log('this is id:', this.showHistory())
    } else {
      this.showHistory.set(true)
      console.log('this is id:', this.showHistory())
    }
      
  }
  // Gets all accounts for the signed on user
  onGetAccount() {
    this.service.getAccounts().subscribe({
      next: (response) => { this.accounts.set(response) },
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
    this.service.getTransactions(acct).subscribe({
      next: (res) => this.transactions = res.reverse(),
      complete: () => this.source.paginator = this.paginator
    })
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
  }



}






