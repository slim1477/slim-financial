import { Routes } from '@angular/router';
import { LoginComponent } from '../app/pages/login/login.component';
import { HomeComponent } from './pages/home/home.component';

export const routes: Routes = [
    {path:"",title: "Home page",component: HomeComponent,pathMatch: "full"},
    {path:"login",component: LoginComponent}
    
    
    
];
