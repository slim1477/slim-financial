import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeComponent } from '../pages/Public/home/home.component';
import { RouterModule, Routes } from '@angular/router';

const publicRoutes : Routes = [
  {path: '', 
    children: [
      {path: '', component:HomeComponent,pathMatch:'full'}
    ]}
]

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    HomeComponent,
    RouterModule.forChild(publicRoutes)
  ]
})
export class PublicModule { }
