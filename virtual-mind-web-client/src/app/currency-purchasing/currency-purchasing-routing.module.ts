import { NgModule } from '@angular/core';
import { CurrencyPurchasingComponent } from './currency-purchasing.component';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {
    path: '',
    component: CurrencyPurchasingComponent
  }
];

@NgModule({
  declarations: [],
  imports: [ RouterModule.forChild(routes) ],
  exports: [ RouterModule ]
})
export class CurrencyPurchasingRoutingModule { }
