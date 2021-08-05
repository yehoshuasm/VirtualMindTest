import { CurrencyExchangeRate } from "../models/currency-exchange.model";

export interface AppState {
    currencyExchangeRates: CurrencyExchangeRate[];
    error: string;
    isLoading: boolean
}