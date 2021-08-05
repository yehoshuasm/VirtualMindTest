import { InjectionToken } from "@angular/core";
import { ActionReducerMap } from "@ngrx/store";
import { AppState } from "./app.state";
import { CurrencyExchangeRateActionsType, CurrencyExchangeRatesActions } from "./currency-exchange-rates.actions";

export const currencyExchangeRatesFeatureKey = 'currencyExchangeRatesFeature';

export const initialState: AppState = {
    currencyExchangeRates: [],
    error: '',
    isLoading: false
};

export function currencyExchangeRatesReducer(state = initialState, actions: CurrencyExchangeRatesActions): AppState {
    switch(actions.type) {
        case CurrencyExchangeRateActionsType.GetCurrencyExchangeRates:
            return {
                ...state,
                isLoading: true,
                error: ''
            };
        case CurrencyExchangeRateActionsType.GetCurrencyExchangeRatesSuccess:
            return {
                ...state,
                currencyExchangeRates: actions.rates,
                isLoading: false,
                error: ''

            };
        case CurrencyExchangeRateActionsType.GetCurrencyExchangeRatesError:
            return {
                ...state,
                currencyExchangeRates: null,
                error: actions.error,
                isLoading: false
            };
        default:
            return state;
    }
}

export const currencyExchangeRatesReducerToken = new InjectionToken<ActionReducerMap<AppState>>('Currency Exchange Rates Reducer');

export const ratesReducerProvider = [{
    provide: currencyExchangeRatesReducerToken,
    useValue: currencyExchangeRatesReducer
}];