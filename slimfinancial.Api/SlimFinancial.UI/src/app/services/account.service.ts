import { inject, Injectable, signal } from '@angular/core';
import { Account } from '../core/common/models/account';
import { Transaction } from '../core/common/models/transaction';
import { Observable } from 'rxjs';
import { HttpClient, HttpErrorResponse, HttpResponse, HttpStatusCode } from '@angular/common/http';
import { AuthService } from './auth.service';

@Injectable()
export class AccountService {
  http = inject(HttpClient);
  // authUser = inject(AuthService).getAuthPerson()
  authUser = AuthService.getAuthPerson()
  url:string=  `https://localhost:7177/api/Account/${this.authUser}`


  getAccounts(): Observable<Account[]> {
    console.log(this.url)
    return this.http.get<Account[]>(this.url)
  }
  
  transactions = signal<Transaction[]>([
    {
      id: 1,
      date: new Date(12 / 15 / 2024),
      description: 'Payroll Deposit',
      credit: 3000,
      debit: 0,
      balance: 5000
    },
    {
      id: 2,
      date: new Date(12 / 15 / 2024),
      description: 'Payroll Deposit',
      credit: 3000,
      debit: 0,
      balance: 5000
    },
    {
      id: 3,
      date: new Date(12 / 15 / 2024),
      description: 'Payroll Deposit',
      credit: 0,
      debit: 3000,
      balance: 5000
    }
  ])
  constructor() { }
}
