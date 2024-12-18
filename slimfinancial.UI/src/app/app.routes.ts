import { RouterModule, Routes } from '@angular/router';
import { NgModule } from '@angular/core';

export const routes: Routes = [
    {path:'home',title: "Home",loadChildren: ()=> import("../app/modules/public.module").then(p => p.PublicModule)},
    {path: 'authentication',title: 'login',loadChildren:() => import("../app/modules/auth/auth.module").then(a => a.AuthModule)},
    {path:'dashboard',title:'dashboard',loadChildren:() => import("../app/modules/dashboard/dashboard.module").then(d => d.DashboardModule)},
    {path:'',redirectTo:'/home',pathMatch:'full'}
];
@NgModule({
    declarations:[],
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})

export class AppRouteModule{}