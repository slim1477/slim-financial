import { Component, inject } from '@angular/core';
import { MaterialModule } from '../../../common/material/material.module';
import { AccountService } from '../../../../services/account.service';
import { Transaction } from '../../../common/models/transaction';

@Component({
  selector: 'app-transaction-history',
  standalone: true,
  imports: [MaterialModule],
  providers: [AccountService],
  templateUrl: './transaction-history.component.html',
  styleUrl: './transaction-history.component.css'
})
export class TransactionHistoryComponent {
  transactions = inject(AccountService);
  tableHeaders = ['ID','Date','Description','Credit','Debit','Balance']
  tableHeader =[
  {
    columnDef: 'ID',
    header: '#',
    cell: (element: Transaction) => `${element.id}`,
  },
  {
    columnDef: 'Date',
    header: 'Date',
    cell: (element: Transaction) => `${element.date.toLocaleDateString()}`,
  },
  {
    columnDef: 'Description',
    header: 'Description',
    cell: (element: Transaction) => `${element.description}`,
  },
  {
    columnDef: 'Credit',
    header: 'Credit',
    cell: (element: Transaction) => `${element.credit}`,
  },
  {
    columnDef: 'Debit',
    header: 'Debit',
    cell: (element: Transaction) => `${element.debit}`,
  },
  {
    columnDef: 'Balance',
    header: 'Balance',
    cell: (element: Transaction) => `${element.balance}`,
  },
  ]

}
