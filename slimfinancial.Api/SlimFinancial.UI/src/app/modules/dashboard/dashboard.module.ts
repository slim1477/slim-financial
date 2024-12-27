import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { DashboardComponent } from '../../pages/Private/dashboard/dashboard.component';
import { OverviewComponent } from '../../pages/Private/overview/overview.component';
import { AccountComponent } from '../../pages/Private/account/account.component';
import { WidgetComponent } from '../../core/components/private-components/widget/widget.component';
import { TransactionHistoryComponent } from '../../core/components/private-components/transaction-history/transaction-history.component';
import { TransferComponent } from '../../core/components/private-components/transfer/transfer.component';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { AuthInterceptor } from '../../interceptor/auth.interceptor';
import { AccountService } from '../../services/account.service';
import { AuthModule } from '../auth/auth.module';
import { AuthService } from '../../services/auth.service';


const dashboardRoutes : Routes = [
  {path: '', component: DashboardComponent,children:[
    {path:'overview',component:OverviewComponent,pathMatch:'full'},
    {path: 'accounts',component: AccountComponent,children:[
      {path: '',redirectTo: 'history',pathMatch:'full'},
      {path: 'overview',component:WidgetComponent},
      {path: 'transfer',component:TransferComponent},
      {path: 'history',component:TransactionHistoryComponent}
    ]},
    {path: '',redirectTo: 'overview',pathMatch:'full'},
    {path:'**',redirectTo:'..home'}
  ]},
]
const accountRoutes: Routes = [
 
]

@NgModule({
  declarations: [],
  imports: [
    CommonModule,OverviewComponent,AccountComponent,AuthModule,
    RouterModule.forChild(dashboardRoutes)
  ],
  providers:[AccountService],
  exports:[RouterModule,AuthModule],

})
export class DashboardModule { }
