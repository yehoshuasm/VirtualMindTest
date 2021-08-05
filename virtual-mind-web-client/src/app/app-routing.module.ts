import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';


const routes: Routes = [
  {
    path: 'cotizaciones',
    loadChildren: () => import('./currency-exchange-rates/currency-exchange-rates.module').then(m => m.CurrencyExchangeRatesModule)
  },
  {
    path: 'compra',
    loadChildren: () => import('./currency-purchasing/currency-purchasing.module').then(m => m.CurrencyPurchasingModule)
  },
  {
    path: '',
    redirectTo: 'cotizaciones',
    pathMatch: 'full'
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
