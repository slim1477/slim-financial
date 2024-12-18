import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoginComponent } from '../../pages/Auth/login/login.component';
import { RouterModule, Routes } from '@angular/router';

const authRoute : Routes = [
  {path:"",component:LoginComponent,
    children:[
      {path:'login',component:LoginComponent},
      {path:'',redirectTo:'login',pathMatch:'full'}
    ]
  }
]

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    LoginComponent,
    RouterModule.forChild(authRoute)
  ]
})
export class AuthModule { }
