import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { DashboardComponent } from '../../pages/Private/dashboard/dashboard.component';



const dashboardRoutes : Routes = [
  {path: "",children: [
    {path: "",redirectTo: 'overview',pathMatch:"full"},
    {path: '',component:DashboardComponent,children:[
      {path: 'overview',
        loadComponent: ()=> import('../../pages/Private/overview/overview.component')
        .then(d => d.OverviewComponent)},
      {path: 'accounts',loadComponent: ()=> import('../../pages/Private/account/account.component')
        .then(a => a.AccountComponent)
      }
    ]}
    
    
  ]}
]
@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forChild(dashboardRoutes)
  ],
  exports:[RouterModule]
})
export class DashboardModule { }
