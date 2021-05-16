import { Component, NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CategoryComponent } from './components/category/category.component';
import { LoginComponent } from './components/login/login.component';
import { MoneyComponent } from './components/money/money.component';
import { ProductAddComponent } from './components/product-add/product-add.component';

import { ProductComponent } from './components/product/product.component';
import { LoginGuard } from './guards/login.guard';

const routes: Routes = [
  {path:"",pathMatch:"full", component:ProductComponent},
  {path:"products", component:ProductComponent},
  {path:"products/category/:kategoriId", component:ProductComponent},
  {path:"products/add",component:ProductAddComponent},
  {path:"money/add",component:MoneyComponent},
  
  {path:"login",component:LoginComponent},
  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
