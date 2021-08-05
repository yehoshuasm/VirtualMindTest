import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CurrencyPurchasingRoutingModule } from './currency-purchasing-routing.module';
import { CurrencyExchangeRatesModule } from '../currency-exchange-rates/currency-exchange-rates.module';
import { ReactiveFormsModule } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input'
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { CurrencyPurchasingComponent } from './currency-purchasing.component';



@NgModule({
  declarations: [ CurrencyPurchasingComponent ],
  imports: [
    CommonModule,
    CurrencyPurchasingRoutingModule,
    CurrencyExchangeRatesModule,
    ReactiveFormsModule,
    MatFormFieldModule,
    MatInputModule,
    MatProgressSpinnerModule
  ]
})
export class CurrencyPurchasingModule { }
