import { Action } from "@ngrx/store";
import { CurrencyExchangeRate } from "../models/currency-exchange.model";


export enum CurrencyExchangeRateActionsType {
    GetCurrencyExchangeRates = '[Currency Exchange Rates] Get Currency Exchange Rates',
    GetCurrencyExchangeRatesSuccess = '[Currency Exchange Rates] Get Currency Exchange Rates Success',
    GetCurrencyExchangeRatesError = '[Currency Exchange Rates] Get Currency Exchange Rates Error'
}

export class GetCurrencyExchangeRates implements Action {
    readonly type = CurrencyExchangeRateActionsType.GetCurrencyExchangeRates;
    constructor() {}
}

export class GetCurrencyExchangeRatesSuccess implements Action {
    readonly type = CurrencyExchangeRateActionsType.GetCurrencyExchangeRatesSuccess;
    constructor(public rates: CurrencyExchangeRate[]) { }
}

export class GetCurrencyExchangeRatesError implements Action {
    readonly type = CurrencyExchangeRateActionsType.GetCurrencyExchangeRatesError;
    constructor(public error: any) { }
}

export type CurrencyExchangeRatesActions = GetCurrencyExchangeRates | GetCurrencyExchangeRatesSuccess | GetCurrencyExchangeRatesError;