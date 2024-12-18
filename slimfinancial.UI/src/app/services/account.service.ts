import { Injectable, signal } from '@angular/core';
import { Account } from '../core/common/models/account';
import { Transaction } from '../core/common/models/transaction';

@Injectable()
export class AccountService {
  accounts = signal<Account[]>([
    {
      id: 1,
      type : 'Savings',
      description : 'Everyday Savings',
      balance : 200
    },
    {
      id: 2,
      type : 'Checking',
      description : 'Checking',
      balance : 500
    },
    {
      id: 3,
      type : 'Checking',
      description : 'Checking',
      balance : 500
    },
    {
      id: 4,
      type : 'Checking',
      description : 'Checking',
      balance : 500
    }
  ])
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
