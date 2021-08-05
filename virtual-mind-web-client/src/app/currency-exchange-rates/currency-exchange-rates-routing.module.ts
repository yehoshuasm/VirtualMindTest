import { NgModule } from '@angular/core';
import { CurrencyExchangeRatesComponent } from './currency-exchange-rates.component';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {
    path: '',
    component: CurrencyExchangeRatesComponent
  }
];


@NgModule({
  imports: [ RouterModule.forChild(routes) ],
  exports: [ RouterModule ]
})
export class CurrencyExchangeRatesRoutingModule { }
