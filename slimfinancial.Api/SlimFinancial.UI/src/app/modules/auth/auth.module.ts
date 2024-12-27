import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoginComponent } from '../../pages/Auth/login/login.component';
import { RouterModule, Routes } from '@angular/router';
import { AuthService } from '../../services/auth.service';


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
  ],
  providers:[AuthService]
})
export class AuthModule { }
