import { inject, Injectable, signal } from '@angular/core';
import { Account } from '../core/common/models/account';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Transaction } from '../core/common/models/transaction';
import { AuthService } from './auth.service';

@Injectable()
export class AccountService {
  private http = inject(HttpClient);
  authUser = inject(AuthService).getAuthPerson()
  accounts = signal<Account[]>([])
  transactions : Transaction[] = []
  private acctUrl: string = `https://localhost:7177/api/Account/${this.authUser}`
  private transactionUrl: string = 'https://localhost:7177/Api/Transaction'


  getAccounts(): Observable<Account[]> {
    return this.http.get<Account[]>(this.acctUrl)
  }
  getTransactions(acct: Account): Observable<Transaction[]> {
    return this.http.get<Transaction[]>(this.transactionUrl.concat(`/${acct.accountNumber}`))
  }

}
