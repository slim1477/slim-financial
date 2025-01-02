import { Component, inject, OnInit, signal, Signal, ViewChild } from '@angular/core';
import { MaterialModule } from '../../../common/material/material.module';
import { AccountService } from '../../../../services/account.service';
import { Transaction } from '../../../common/models/transaction';
import { ROUTER_OUTLET_DATA } from '@angular/router';
import { transfer } from '../../../common/models/transfer';
import { HttpErrorResponse } from '@angular/common/http';
import { MatPaginator } from '@angular/material/paginator';
import { formatDate } from '@angular/common';
//import { MatTableDataSource } from '@angular/material/table';


@Component({
  selector: 'app-transaction-history',
  standalone: true,
  imports: [MaterialModule],
  providers: [AccountService],
  templateUrl: './transaction-history.component.html',
  styleUrl: './transaction-history.component.css'
})
export class TransactionHistoryComponent implements OnInit {
  service = inject(AccountService);
  account = inject(ROUTER_OUTLET_DATA) as Signal<transfer>
  errorMessage = signal<HttpErrorResponse>(Object())
  transactions = signal<Transaction[]>([])
  //dataSource = new MatTableDataSource(this.transactions())
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
  getTransactions() {
    //const accounts = this.service.getAccounts().pipe(map())
    this.service.getTransactions(this.account().source).subscribe({
      next: (response) => {
        this.transactions.set(response)
        console.log('from get trans', this.account().source)
        console.log(response)
      },
      error: (error) => this.errorMessage.set(error)
    })
  }


  ngOnInit() {
    this.getTransactions()
    console.log('from transactionHistory', this.transactions())
   
  }
}
