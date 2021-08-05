
import { Injectable } from "@angular/core";
import { Actions, createEffect, ofType } from "@ngrx/effects";
import { forkJoin, of } from "rxjs";
import { CurrencyExchangeRate } from "../models/currency-exchange.model";
import { GetCurrencyExchangeRates, GetCurrencyExchangeRatesSuccess, GetCurrencyExchangeRatesError, CurrencyExchangeRateActionsType } from "../state/currency-exchange-rates.actions";
import { concatMap, map, catchError } from "rxjs/operators";
import { CurrencyExchangeRatesApiService } from "../services/currency-exchange-rates-api.service";

@Injectable()
export class CurrencyExchangeRatesEffects {
    constructor(
        private actions$: Actions<GetCurrencyExchangeRates | GetCurrencyExchangeRatesSuccess | GetCurrencyExchangeRatesError>,
        private currencyExchangeRatesApiService: CurrencyExchangeRatesApiService
    ) { }

    getCurrencyExchangeRates$ = createEffect(() => this.actions$.pipe(
        ofType(CurrencyExchangeRateActionsType.GetCurrencyExchangeRates),
        concatMap(() => {
            let batch = [];

            batch.push(this.currencyExchangeRatesApiService.getCurrencyExchangeRate$('dolar'));
            batch.push(this.currencyExchangeRatesApiService.getCurrencyExchangeRate$('real'));

            return forkJoin(batch).pipe(
                map((rates: CurrencyExchangeRate[]) => {
                    return new GetCurrencyExchangeRatesSuccess(rates);
                }),
                catchError(error => {
                    return of(new GetCurrencyExchangeRatesError({ error }));
                })
            );
        })
    ));
}
