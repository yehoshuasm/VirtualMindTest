import { Injectable } from '@angular/core';
import { createFeatureSelector, createSelector, select, Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { take } from 'rxjs/operators';
import { CurrencyExchangeRate } from '../models/currency-exchange.model';
import { AppState } from '../state/app.state';
import { GetCurrencyExchangeRates } from '../state/currency-exchange-rates.actions';
import { currencyExchangeRatesFeatureKey } from '../state/currency-exchange-rates.reducer';

@Injectable({
  providedIn: 'root'
})
export class CurrencyExchangeRatesService {

  constructor(
    private store: Store<AppState>) { }

  public optimisticLoadCurrencyExchangeRates(): void {
    this.currencyExchangeRates.pipe(
        take(1)
    ).subscribe(() => this.getCurrencyExchangeRate$());
  }

  getCurrencyExchangeRate$(): void {
    return this.store.dispatch(new GetCurrencyExchangeRates());
  }

  get currencyExchangeRates(): Observable<CurrencyExchangeRate[]> {
    return this.store.pipe(
      select(
        createSelector(
          createFeatureSelector<AppState>(
            currencyExchangeRatesFeatureKey
          ), (state: AppState) => state.currencyExchangeRates)
        )
      );
  }

  get isLoading(): Observable<boolean> {
    return this.store.pipe(
      select(
        createSelector(
          createFeatureSelector<AppState>(
            currencyExchangeRatesFeatureKey
          ), (state: AppState) => state.isLoading
        )
      )
    );
  }

  get error(): Observable<string> {
    return this.store.pipe(
      select(
        createSelector(
          createFeatureSelector<AppState>(
            currencyExchangeRatesFeatureKey
          ), (state: AppState) => state.error
        )
      )
    );
  }
}
