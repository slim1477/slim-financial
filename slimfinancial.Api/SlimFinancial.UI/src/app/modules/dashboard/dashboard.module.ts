import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TransactionHistoryComponent } from '../../core/components/private-components/transaction-history/transaction-history.component';
import { TransferComponent } from '../../core/components/private-components/transfer/transfer.component';
import { WidgetComponent } from '../../core/components/private-components/widget/widget.component';
import { AccountComponent } from '../../pages/Private/account/account.component';
import { DashboardComponent } from '../../pages/Private/dashboard/dashboard.component';
import { OverviewComponent } from '../../pages/Private/overview/overview.component';
import { PersonService } from '../../services/person.service';
import { AuthModule } from '../auth/auth.module';
import { DetailComponent } from '../../core/components/private-components/detail/detail.component';


const dashboardRoutes : Routes = [
  {path: '', component: DashboardComponent,children:[
    {path:'overview',component:OverviewComponent,pathMatch:'full'},
    {
      path: 'accounts', component: AccountComponent, children: [
        { path: 'details', component: DetailComponent },
      {path: 'transfer',component:TransferComponent},
      { path: 'history', component: TransactionHistoryComponent },
      { path: '', redirectTo: 'details', pathMatch: 'full' }
    ]},
    {path: '',redirectTo: 'overview',pathMatch:'full'},
    {path:'**',redirectTo:'../home'}
  ]},
]

@NgModule({
  declarations: [],
  imports: [
    CommonModule,OverviewComponent,AccountComponent,AuthModule,
    RouterModule.forChild(dashboardRoutes)
  ],
  providers:[PersonService],
  exports:[RouterModule,AuthModule],

})
export class DashboardModule { }
