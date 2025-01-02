import { Component, inject, OnInit, Signal } from '@angular/core';
import { ROUTER_OUTLET_DATA } from '@angular/router';
import { Account } from '../../../common/models/account';
import { JsonPipe } from '@angular/common';
import { transfer } from '../../../common/models/transfer';

@Component({
  selector: 'app-detail',
  standalone: true,
  imports: [JsonPipe],
  templateUrl: './detail.component.html',
  styleUrl: './detail.component.css'
})
export class DetailComponent implements OnInit {

  account = inject(ROUTER_OUTLET_DATA) as Signal<transfer>


  ngOnInit(): void {
    console.log(this.account().source)
  }
}
