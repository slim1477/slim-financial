import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { DashboardComponent } from '../../pages/Private/dashboard/dashboard.component';
import { OverviewComponent } from '../../pages/Private/overview/overview.component';
import { AccountComponent } from '../../pages/Private/account/account.component';
import { WidgetComponent } from '../../core/components/private-components/widget/widget.component';
import { TransactionHistoryComponent } from '../../core/components/private-components/transaction-history/transaction-history.component';
import { TransferComponent } from '../../core/components/private-components/transfer/transfer.component';


const dashboardRoutes : Routes = [
  {path: '', component: DashboardComponent,children:[
    {path:'overview',component:OverviewComponent,pathMatch:'full'},
    {path: 'accounts',component: AccountComponent,children:[
      {path: '',redirectTo: 'history',pathMatch:'full'},
      {path: 'overview',component:WidgetComponent},
      {path: 'transfer',component:TransferComponent},
      {path: 'history',component:TransactionHistoryComponent},
      
    ]},
    {path: '',redirectTo: 'overview',pathMatch:'full'},
    {path:'**',redirectTo:'..home'}
  ]},
]
const accountRoutes: Routes = [
 
]
// const dashboardRoutes : Routes = [
//     {path: '',loadComponent: () => import("../../pages/Private/dashboard/dashboard.component").then(d => d.DashboardComponent),children: [
//       {path: 'dashboard/overview',
//         loadComponent: ()=> import('../../pages/Private/overview/overview.component')
//         .then(d => d.OverviewComponent)},
//       {path: 'accounts',loadComponent: ()=> import('../../pages/Private/account/account.component')
//         .then(a => a.AccountComponent)
//       },
//     ]},
     
//       {path: "",redirectTo: 'overview',pathMatch:"full"},
//     ]
  

@NgModule({
  declarations: [],
  imports: [
    CommonModule,OverviewComponent,AccountComponent,
    RouterModule.forChild(dashboardRoutes)
   
  ],
  exports:[RouterModule]
})
export class DashboardModule { }
