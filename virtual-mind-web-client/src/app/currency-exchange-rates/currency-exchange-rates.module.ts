import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { CurrencyExchangeRatesComponent } from './currency-exchange-rates.component';
import { CurrencyExchangeRatesRoutingModule } from './currency-exchange-rates-routing.module';
import { StoreModule } from '@ngrx/store';
import { EffectsModule } from '@ngrx/effects';
import { CurrencyExchangeRatesEffects } from '../effects/currency-exchange-rates.effects';
import { currencyExchangeRatesFeatureKey, currencyExchangeRatesReducerToken, ratesReducerProvider } from '../state/currency-exchange-rates.reducer';



@NgModule({
  declarations: [CurrencyExchangeRatesComponent],
  imports: [
    CommonModule,
    MatProgressSpinnerModule,
    CurrencyExchangeRatesRoutingModule,
    StoreModule.forFeature(currencyExchangeRatesFeatureKey, currencyExchangeRatesReducerToken),
    EffectsModule.forFeature([ CurrencyExchangeRatesEffects ])
  ],
  exports: [ CurrencyExchangeRatesComponent ],
  providers: [ ratesReducerProvider ]
})
export class CurrencyExchangeRatesModule { }
